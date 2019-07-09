using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using HiQoDataGenerator.Web.ModelsValidation;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}
