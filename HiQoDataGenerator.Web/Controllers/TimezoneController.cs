using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Linq;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimezoneController : ControllerBase
    {
        private readonly IFieldTypeService _timezonesService;

        public TimezoneController(IFieldTypeService timezonesService) => _timezonesService = timezonesService;

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var timezones = _timezonesService.GetAll();
            return new string[] { timezones.Count().ToString() };
        }
            
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
