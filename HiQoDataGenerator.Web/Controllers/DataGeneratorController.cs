using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Web.Interfaces;
using Microsoft.AspNetCore.Http;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DataGeneratorController : RootController
    {
        private readonly IDataGeneratorService _dataGenerator;
        private readonly IDatasetService _datasetService;
        private readonly IGeneratedObjectFileSystemService _generatedObjectFileSystemService;
        private readonly IBackgroundDataSavingTasksQueue _backgroundDataSavingTasksQueue;

        private readonly Dictionary<string, Func<IEnumerable<GeneratedObjectViewModel>, string>> _converters =
            new Dictionary<string, Func<IEnumerable<GeneratedObjectViewModel>, string>>();

        public DataGeneratorController(IMapperFactory mapperFactory,
            IDataGeneratorService dataGenerator,
            IDatasetService dateService,
            IGeneratedObjectFileSystemService generatedObjectFileSystemService,
            IBackgroundDataSavingTasksQueue backgroundDataSavingTasksQueue) : base(mapperFactory)
        {
            _dataGenerator = dataGenerator;
            _datasetService = dateService;
            _generatedObjectFileSystemService = generatedObjectFileSystemService;
            
            _converters["xml"] = Converter.ObjectToXml;
            _converters["json"] = Converter.ObjectToJson;

            _backgroundDataSavingTasksQueue = backgroundDataSavingTasksQueue;
        }

        /// <summary>
        ///     Generate data from configurable object
        /// </summary>
        /// <returns>Status code 200 and Json or Xml File</returns>
        [HttpPost]
        [Route("{resultType?}/{count?}")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> GenerateObjectAsync([FromBody] ConfigurableObjectViewModel configurableObject,
            string resultType, int? count)
        {
            var datasetIds = configurableObject.Fields
                .Where(f => f.DatasetId != null)
                .Select(f => f.DatasetId.GetValueOrDefault())
                .Distinct().ToArray();

            var datasetPrototypes = datasetIds.Any() ? new List<DatasetPrototype>() : null;

            foreach (var datasetId in datasetIds)
            {
                var datasetValues = await _datasetService.GetValuesByDatasetIdAsync(datasetId);
                var prototypeValues = datasetValues.Select(v => v.Value).ToList<dynamic>();
                var prototype = new DatasetPrototype(datasetId, prototypeValues);
                datasetPrototypes?.Add(prototype);
            }

            var modelForGenerate = _mapper.Map<ConfigurablePrototype>(configurableObject);
            var result = _mapper.Map<IEnumerable<GeneratedObjectViewModel>>(_dataGenerator.GenerateMany(modelForGenerate, count ?? 1, datasetPrototypes)).ToList();

            SaveGeneratedObjects(result);

            if (resultType == null)
            {
                return CreatedAtRoute(RouteData.Values, result);
            }

            var fileContents = _converters[resultType]?.Invoke(result) ?? throw new ArgumentException();
            return File( Encoding.ASCII.GetBytes(fileContents), $"application/{resultType}",
                $"{result.First().Name}_{result.First().DateCreated:s}.{resultType}".Replace(":","").Replace("-",""));

        }

        private void SaveGeneratedObjects(IEnumerable<GeneratedObjectViewModel> generatedObject)
        {
            _backgroundDataSavingTasksQueue.QueueBackgroundWorkItem(async token =>
            {
                var path = await _generatedObjectFileSystemService.CreateFileAsync(_mapper.Map<IEnumerable<GeneratedObjectModel>>(generatedObject));
                return new FileMetadataModel(0, path, 1);
            });
        }

    }
}
