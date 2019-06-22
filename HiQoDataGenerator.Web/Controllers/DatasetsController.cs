using System;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels.Dataset;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DatasetsController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly IDefinedDatasetsService _definedDatasetsService;

        public DatasetsController(ILoggerFactory loggerFactory, IMapperFactory mapperFactory, IDefinedDatasetsService definedDatasetsService)
        {
            _logger = loggerFactory.CreateLogger(GetType().Name);
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
            _definedDatasetsService = definedDatasetsService;
        }

        // GET: api/Datasets/5
        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            _logger.LogInformation("Trying to get dataset by name: {0}", name);
            var datasets = _mapper.Map<DatasetViewModel<string>>(_definedDatasetsService.GetSetOfStringByName(name));

            return Ok(datasets);
        }

        // POST: api/Datasets
        [HttpPost("{datasetName}")]
        public IActionResult Post(string datasetName, [FromBody] string value)
        {
            _logger.LogInformation("Trying to add {0} in dataset - {1}", value, datasetName);
            _definedDatasetsService.AddValueIn(datasetName, _mapper.Map<DatasetValueModel<string>>(value));
            return Ok();
        }

        // PUT: api/Datasets/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) => throw new NotImplementedException();

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id) => throw new NotImplementedException();
    }
}
