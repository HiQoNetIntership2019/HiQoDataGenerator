using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using HiQoDataGenerator.Web.Extensions;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DataGeneratorController : RootController
    {
        private readonly IDataGeneratorService _dataGenerator;

        public DataGeneratorController(IMapperFactory mapperFacroty, IDataGeneratorService dataGenerator) : base(mapperFacroty)
        {
            _dataGenerator = dataGenerator;
        }

        /// <summary>
        ///     Generated data from configurable object
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost]
        public IActionResult Post([FromBody] ConfigurableObjectViewModel configurableObject)
        {
            var modelForGenerate = _mapper.Map<ConfigurablePrototype>(configurableObject);
            var result = _dataGenerator.Generate(modelForGenerate);
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
