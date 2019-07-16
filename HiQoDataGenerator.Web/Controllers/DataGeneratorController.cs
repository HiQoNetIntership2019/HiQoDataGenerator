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
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DataGeneratorController : RootController
    {
        private readonly IDataGeneratorService _dataGenerator;
        private readonly IDefinedDatasetService _definedDatasetService;
        private readonly ICustomDatasetService _customDatasetService;

        public DataGeneratorController(IMapperFactory mapperFactory, IDataGeneratorService dataGenerator, IDefinedDatasetService definedDatasetService, ICustomDatasetService customDatasetService) : base(mapperFactory)
        {
            _dataGenerator = dataGenerator;
            _definedDatasetService = definedDatasetService;
            _customDatasetService = customDatasetService;
        }

        /// <summary>
        ///     Generated data from configurable object
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConfigurableObjectViewModel configurableObject)
        {
            var datasetPrototypes = new List<DatasetPrototype>();
            var datasetViewModels = configurableObject.Fields.Select(f => f.Dataset).Distinct();
            foreach (var datasetViewModel in datasetViewModels)
            {
                if (datasetViewModel.IsDefined)
                {
                    var definedDatasetModel = await _definedDatasetService.GetDatasetWithValuesById(datasetViewModel.Id);
                    var prototype = _mapper.Map<DatasetPrototype>(definedDatasetModel);
                    datasetPrototypes.Add(prototype);
                }
                else
                {
                    var customDatasetModel = await _customDatasetService.GetDatasetWithValuesById(datasetViewModel.Id);
                    var prototype = _mapper.Map<DatasetPrototype>(customDatasetModel);
                    datasetPrototypes.Add(prototype);
                }
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
