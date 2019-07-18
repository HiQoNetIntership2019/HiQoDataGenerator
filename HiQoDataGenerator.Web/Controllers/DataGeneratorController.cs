using System.Collections.Generic;
using System.Linq;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DataGeneratorController : RootController
    {
        private readonly IDataGeneratorService _dataGenerator;
        private readonly IDatasetService _datasetService;

        public DataGeneratorController(IMapperFactory mapperFactory, IDataGeneratorService dataGenerator, IDatasetService datasetService) : base(mapperFactory)
        {
            _dataGenerator = dataGenerator;
            _datasetService = datasetService;
        }

        /// <summary>
        ///     Generated data from configurable object
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConfigurableObjectViewModel configurableObject)
        {
            var datasetIds = configurableObject.Fields
                .Select(f => f.DatasetId.GetValueOrDefault())
                .Distinct()
                .ToArray();

            var datasetPrototypes = datasetIds.Any() ? new List<DatasetPrototype>() : null;

            foreach (var datasetId in datasetIds)
            {
                var datasetValues = await _datasetService.GetValuesByDatasetIdAsync(datasetId);
                var prototypeValues = datasetValues.Select(v => v.Value).ToList<dynamic>();
                var prototype = new DatasetPrototype(datasetId, prototypeValues);
                datasetPrototypes?.Add(prototype);
            }
            
            var modelForGenerate = _mapper.Map<ConfigurablePrototype>(configurableObject);

            var result = _dataGenerator.Generate(modelForGenerate, datasetPrototypes);
            return Ok(_mapper.Map<GeneratedObjectViewModel>(result));
        }

        /// <summary>
        ///     Generate data from configurable object
        /// </summary>
        /// <returns>Status code 200 and Json File</returns>
        [HttpPost]
        [Route("Json")]
        public IActionResult GenerateJsonObject([FromBody] ConfigurableObjectViewModel configurableObject)
        {
            var modelForGenerate = _mapper.Map<ConfigurablePrototype>(configurableObject);
            var result = _mapper.Map<GeneratedObjectViewModel>(_dataGenerator.Generate(modelForGenerate));

            string json = Converter.ObjectToJson(result);
            var fileContents = Encoding.ASCII.GetBytes(json);
            return File(fileContents, "application/json", $"{result.Name}_{result.DateCreated}.json");
        }

        /// <summary>
        ///     Generate data from configurable object
        /// </summary>
        /// <returns>Status code 200 and Xml File</returns>
        [HttpPost]
        [Route("Xml")]
        public IActionResult GenerateXmlObject([FromBody] ConfigurableObjectViewModel configurableObject)
        {
            var modelForGenerate = _mapper.Map<ConfigurablePrototype>(configurableObject);
            var result = _mapper.Map<GeneratedObjectViewModel>(_dataGenerator.Generate(modelForGenerate));

            string xml = Converter.ObjectToXml(result);
            var fileContents = Encoding.ASCII.GetBytes(xml);
            return File(fileContents, "application/xml", $"{result.Name}_{result.DateCreated}.xml");
        }
    }
}
