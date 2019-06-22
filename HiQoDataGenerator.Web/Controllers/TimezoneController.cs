using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using AutoMapper;
using HiQoDataGenerator.Web.Attributes;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggingAttribute))]
    public class TimezoneController : ControllerBase
    {
        private readonly ITimezonesService _timezonesService;
        private readonly IMapper _mapper;

        public TimezoneController(ITimezonesService timezonesService, IMapperFactory mapperFactory)
        {
            _timezonesService = timezonesService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }

        [HttpGet]
        public IActionResult Get() => Ok(_mapper.Map<IEnumerable<TimezoneViewModel>>(_timezonesService.GetAll()));
        


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var timezone = await _timezonesService.GetByIdAsync(id);
            return Ok(_mapper.Map<TimezoneViewModel>(timezone));
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TimezoneViewModel model) =>
            Ok(await _timezonesService.AddAsync(_mapper.Map<TimezoneModel>(model)));


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) => Ok(await _timezonesService.RemoveByIdAsync(id));
    }
}
