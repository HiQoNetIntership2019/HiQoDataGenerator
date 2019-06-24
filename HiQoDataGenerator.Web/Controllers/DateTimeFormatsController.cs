using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using System.Net;
using Microsoft.Extensions.Logging;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeFormatsController : ControllerBase
    {
        private readonly IDateTimeFormatService _dateTimeFormatService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly string _loggerName = "DateTimeFormatLogger";

        public DateTimeFormatsController(IDateTimeFormatService dateTimeFormatService, IMapperFactory mapperFactory, ILoggerFactory loggerFactory)
        {
            _dateTimeFormatService = dateTimeFormatService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
            _logger = loggerFactory.CreateLogger(_loggerName);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dateTimeFormatModels = _dateTimeFormatService.GetAll();
            var dateTimeFormatViewModels = _mapper.Map<IEnumerable<DateTimeFormatViewModel>>(dateTimeFormatModels);
            _logger.LogInformation("Get all DateTime formats");
            return Ok(dateTimeFormatViewModels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var dateTimeFormatModel = await _dateTimeFormatService.GetByIdAsync(id);
            var dateTimeFormatViewModel = _mapper.Map<DateTimeFormatViewModel>(dateTimeFormatModel);
            _logger.LogInformation("Get DateTime format with id {0}", dateTimeFormatViewModel.Id);
            return Ok(dateTimeFormatViewModel);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(DateTimeFormatViewModel dateTimeFormatViewModel)
        {
            var dateTimeFormatModel = _mapper.Map<DateTimeFormatModel>(dateTimeFormatViewModel);

            await _dateTimeFormatService.AddAsync(dateTimeFormatModel);            
            _logger.LogInformation("Add DateTime format <{0}> ", dateTimeFormatViewModel.Value);
            return Ok();
        }

        [HttpPost("Range")]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(IEnumerable<DateTimeFormatViewModel> dateTimeFormatViewModels)
        {            
            var dateTimeFormatModels = _mapper.Map<IEnumerable<DateTimeFormatModel>>(dateTimeFormatViewModels);

            await _dateTimeFormatService.AddRangeAsync(dateTimeFormatModels);
            _logger.LogInformation("Add range of DateTime formats");
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _dateTimeFormatService.RemoveByIdAsync(id);
            _logger.LogInformation("Delete DateTime format with id {0}", id);
            return NoContent();
        }
    }
}
