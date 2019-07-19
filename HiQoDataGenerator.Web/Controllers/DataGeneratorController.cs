using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Objects;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Web.Interfaces;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DataGeneratorController : RootController
    {
        private readonly IDataGeneratorService _dataGenerator;
        private readonly IDatasetService _datasetService;
        private readonly IGeneratedObjectFileSystemService _generatedObjectFileSystemService;
        private readonly IBackgroundDataSavingTasksQueue _backgroundDataSavingTasksQueue;

        private readonly Dictionary<string, Func<object, string>> _converters =
            new Dictionary<string, Func<object, string>>();

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
        [Route("{resultType?}")]
        public async Task<IActionResult> GenerateObject([FromBody] ConfigurableObjectViewModel configurableObject,
            string resultType)
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
            var result = _mapper.Map<GeneratedObjectViewModel>(_dataGenerator.Generate(modelForGenerate, datasetPrototypes));

            SaveGeneratedObjects(result);

            if (resultType == null)
            {
                return Ok(result);
            }

            var fileContents = _converters[resultType]?.Invoke(result) ?? throw new ArgumentException();
            return File(fileContents, $"application/{resultType}",
                $"{result.Name}_{result.DateCreated:s}.{resultType}".Replace(":","").Replace("-",""));

        }

        private void SaveGeneratedObjects(GeneratedObjectViewModel generatedObject)
        {
            _backgroundDataSavingTasksQueue.QueueBackgroundWorkItem(async token =>
            {
                var path = await _generatedObjectFileSystemService.CreateFile(_mapper.Map<GeneratedObjectModel>(generatedObject));
                return new FileMetadataModel(0, path, 1);
            });
        }

    }
}
