using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefinedDatasetsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IDefinedDatasetsService _definedDatasetsService;

        public DefinedDatasetsController(ILoggerFactory loggerFactory, IMapperFactory mapperFactory, IDefinedDatasetsService definedDatasetsService)
        {
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
            _definedDatasetsService = definedDatasetsService;
        }


        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            _logger.LogInformation("Trying to get dataset by name: {0}", name);

            var datasets = _mapper.Map<DatasetViewModel<string>>(_definedDatasetsService.GetSetOfStringByName(name));
            return Ok(datasets);
        }


        [HttpPost("{datasetName}")]
        public IActionResult Post(string datasetName, [FromBody] string value)
        {
            _logger.LogInformation("Trying to add {0} in dataset - {1}", value, datasetName);

            _definedDatasetsService.AddValueIn(datasetName, new DatasetValueModel<string>(value));
            return Ok();
        }


        [HttpDelete("{datasetName}/{id}")]
        public IActionResult Delete(string datasetName, int id)
        {
            _logger.LogInformation("Trying remove by id {1} from {0}", datasetName, id);

            _definedDatasetsService.RemoveValueByIdFrom<string>(datasetName, id);
            return Ok();
        }
    }
}
