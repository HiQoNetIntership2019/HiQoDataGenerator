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
        public IEnumerable<TimezoneViewModel> Get()
            => _timezonesService.GetAll().Select(timezone => new TimezoneViewModel()
            {
                Id = timezone.Id,
                Value = timezone.Value
            });


        [HttpGet("{id}")]
        public async Task<TimezoneViewModel> Get(int id)
        {
            _logger.LogInformation("Trying getting timezone by {0} id", id);

            var timezone = await _timezonesService.GetById(id);
            return timezone == null ? null :
                new TimezoneViewModel()
                {
                    Id = timezone.Id,
                    Value = timezone.Value
                };
        }

        [HttpPost]
        public void Post([FromBody] TimezoneViewModel model)
        {
            _logger.LogInformation("Trying adding timezone with value - {0}", model.Value);

            _timezonesService.Add(new TimezoneModel(model.Value));
        }

     
        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            _logger.LogInformation("Trying removed timezone by {0} id", id);

            return await _timezonesService.RemoveById(id);
        } 
    }
}
