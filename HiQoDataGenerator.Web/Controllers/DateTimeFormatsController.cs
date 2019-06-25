using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Attributes;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggingAttribute))]
    public class DateTimeFormatsController : ControllerBase
    {
        private readonly IDateTimeFormatService _dateTimeFormatService;
        private readonly IMapper _mapper;

        public DateTimeFormatsController(IDateTimeFormatService dateTimeFormatService, IMapperFactory mapperFactory)
        {
            _dateTimeFormatService = dateTimeFormatService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dateTimeFormatModels = _dateTimeFormatService.GetAll();
            var dateTimeFormatViewModels = _mapper.Map<IEnumerable<DateTimeFormatViewModel>>(dateTimeFormatModels);
            return Ok(dateTimeFormatViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dateTimeFormatModel = await _dateTimeFormatService.GetByIdAsync(id);
            var dateTimeFormatViewModel = _mapper.Map<DateTimeFormatViewModel>(dateTimeFormatModel);
            return Ok(dateTimeFormatViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DateTimeFormatViewModel dateTimeFormatViewModel)
        {
            var dateTimeFormatModel = _mapper.Map<DateTimeFormatModel>(dateTimeFormatViewModel);

            await _dateTimeFormatService.AddAsync(dateTimeFormatModel);            
            return Ok();
        }

        [HttpPost("Range")]
        public async Task<IActionResult> Post(IEnumerable<DateTimeFormatViewModel> dateTimeFormatViewModels)
        {            
            var dateTimeFormatModels = _mapper.Map<IEnumerable<DateTimeFormatModel>>(dateTimeFormatViewModels);

            await _dateTimeFormatService.AddRangeAsync(dateTimeFormatModels);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _dateTimeFormatService.RemoveByIdAsync(id);
            return NoContent();
        }
    }
}
