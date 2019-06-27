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
    public class CustomDatasetsController : ControllerBase
    {
        private readonly ICustomDatasetService _customDatasetService;
        private readonly IMapper _mapper;

        public CustomDatasetsController(ICustomDatasetService customDatasetService, IMapperFactory mapperFactory)
        {
            _customDatasetService = customDatasetService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }
        //ok
        [HttpGet]
        public IActionResult Get()
        {
            var customDatasetModels = _customDatasetService.GetAll();
            var customDatasetViewModels = _mapper.Map<IEnumerable<CustomDatasetViewModel>>(customDatasetModels);
            return Ok(customDatasetViewModels);
        }

        //ok
        [HttpGet]
        [Route("Values")]
        public IActionResult GetAll()
        {
            var customDatasetValueModels = _customDatasetService.GetAllValues();
            var customDatasetValueViewModels = _mapper.Map<IEnumerable<CustomDatasetValueViewModel>>(customDatasetValueModels);
            return Ok(customDatasetValueViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customDatasetModel = await _customDatasetService.GetByIdAsync(id);
            var customDatasetViewModel = _mapper.Map<CustomDatasetViewModel>(customDatasetModel);
            return Ok(customDatasetViewModel);
        }



        /*[HttpGet("values")]
        public IActionResult GetWithValues()
        {
            var customDatasetsModels = _customDatasetService.GetAll();
            //var dateTimeFormatViewModels = _mapper.Map<IEnumerable<DateTimeFormatViewModel>>(dateTimeFormatModels);
            return Ok(customDatasetsModels);
        }

        /*
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var dateTimeFormatModel = await _customDatasetService.GetByIdAsync(id);
            //var dateTimeFormatViewModel = _mapper.Map<DateTimeFormatViewModel>(dateTimeFormatModel);
            return Ok(dateTimeFormatViewModel);
        }
        /*
        [HttpPost]
        public async Task<IActionResult> Post(DateTimeFormatViewModel dateTimeFormatViewModel)
        {
            var dateTimeFormatModel = _mapper.Map<DateTimeFormatModel>(dateTimeFormatViewModel);

            await _customDatasetService.AddAsync(dateTimeFormatModel);
            return Ok();
        }

        [HttpPost("Range")]
        public async Task<IActionResult> Post(IEnumerable<DateTimeFormatViewModel> dateTimeFormatViewModels)
        {
            var dateTimeFormatModels = _mapper.Map<IEnumerable<DateTimeFormatModel>>(dateTimeFormatViewModels);

            await _customDatasetService.AddRangeAsync(dateTimeFormatModels);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customDatasetService.RemoveByIdAsync(id);
            return NoContent();
        }*/
    }
}
