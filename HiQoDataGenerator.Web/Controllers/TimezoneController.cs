using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Linq;
using System;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimezoneController : ControllerBase
    {
        private readonly ITimezonesService _timezonesService;

        public TimezoneController(ITimezonesService timezonesService) => _timezonesService = timezonesService;

        [HttpGet]
        public IEnumerable<string> Get() => throw new NotImplementedException();

        [HttpGet("{id}", Name = "Get")]
        public string Get(int id) => throw new NotImplementedException();

        [HttpPost]
        public void Post([FromBody] string value) => throw new NotImplementedException();

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) => throw new NotImplementedException();
        [HttpDelete("{id}")]

        public void Delete(int id) => throw new NotImplementedException();
    }
}
