using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using AutoMapper;
using System.Net;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimezoneController : ControllerBase
    {
        private readonly ITimezonesService _timezonesService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly string _loggerName = "TimezoneController";

        public TimezoneController(ITimezonesService timezonesService, ILoggerFactory loggerFactory, IMapperFactory mapperFactory)
        {
            _timezonesService = timezonesService;
            _logger = loggerFactory.CreateLogger(_loggerName);
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Get all Timezones");
            
            return Ok(_mapper.Map<IEnumerable<TimezoneViewModel>>(_timezonesService.GetAll()));
        }


        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("Trying getting timezone by {0} id", id);

            var timezone = await _timezonesService.GetByIdAsync(id);
            if (timezone == null)
            {
                _logger.LogError("Timezone with id {0} not found", id);
                return NotFound();
            }            
          
            return Ok(_mapper.Map<TimezoneViewModel>(timezone));
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post([FromBody] TimezoneViewModel model)
        {
            _logger.LogInformation("Trying adding timezone with value - {0}", model.Value);

            if (await _timezonesService.AddAsync(_mapper.Map<TimezoneModel>(model)))
            {
                return Ok();
            }

            _logger.LogError("Bad request: id - {0}; value - {1}", model.Id, model.Value);
            return BadRequest();
        }

     
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("Trying removed timezone by {0} id", id);

            if (await _timezonesService.RemoveByIdAsync(id))
            {
                return Ok();
            }

            _logger.LogError("Bad request: id - {0}", id);
            return BadRequest();
        } 
    }
}
