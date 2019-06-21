using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimezoneController : ControllerBase
    {
        private readonly ITimezonesService _timezonesService;
        private readonly ILogger _logger;
        private readonly string _loggerName = "RequestInfoLogger";

        public TimezoneController(ITimezonesService timezonesService, ILoggerFactory loggerFactory)
        {
            _timezonesService = timezonesService;
            _logger = loggerFactory.CreateLogger(_loggerName);
        }

        [HttpGet]
        public IEnumerable<string> Get()
            => _timezonesService.GetAll().Select(timezone => timezone.Value);


        [HttpGet("{id}", Name = "Get")]
        public async Task<string> Get(int id)
        {
            _logger.LogInformation("Trying getting timezone by {0} id", id);

            var timezone = await _timezonesService.GetById(id);
            return timezone?.Value;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
            // TO DO: Value will be in json format
            _logger.LogInformation("Trying adding timezone with value - {0}", value);

            _timezonesService.Add(new TimezoneModel(value));
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public async void Delete(int id)
        {
            _logger.LogInformation("Trying removed timezone by {0} id", id);

            await _timezonesService.RemoveById(id);
        } 
    }
}
