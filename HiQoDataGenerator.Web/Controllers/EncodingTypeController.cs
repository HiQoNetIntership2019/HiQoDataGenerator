using System.Collections.Generic;
using AutoMapper;
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
    public class EncodingTypeController : ControllerBase
    {
        private readonly IEncodingTypesService _encodingTypesService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly string _loggerName = "RequestInfoLogger";

        public EncodingTypeController(IEncodingTypesService encodingTypesService, IMapperFactory mapperFactory, ILoggerFactory loggerFactory)
        {
            _encodingTypesService = encodingTypesService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
            _logger = loggerFactory.CreateLogger(_loggerName);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var encodingTypeModels = _encodingTypesService.GetAll();
            var encodingTypeViewModels = _mapper.Map<IEnumerable<EncodingTypeViewModel>>(encodingTypeModels);
            _logger.LogInformation("[SUCCESS] Get all EncodingTypes");
            return Ok(encodingTypeViewModels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var encodingTypeModel = await _encodingTypesService.GetByIdAsync(id);
            if (encodingTypeModel == null)
            {
                _logger.LogInformation("[ERROR] Can't get EncodingType with id {0} !", id);
                return NotFound();
            }

            var encodingTypeViewModel = _mapper.Map<EncodingTypeViewModel>(encodingTypeModel);
            return Ok(encodingTypeViewModel);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(EncodingTypeViewModel encodingTypeViewModel)
        {
            var encodingTypeModel = _mapper.Map<EncodingTypeModel>(encodingTypeViewModel);
            var isAdded = await _encodingTypesService.AddAsync(encodingTypeModel);

            if (!isAdded)
            {
                _logger.LogInformation("[ERROR] Can't add EncodingType {0}", encodingTypeViewModel.Name);
                return BadRequest();
            }
            return Ok(encodingTypeModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            bool isRemoved = await _encodingTypesService.RemoveByIdAsync(id);

            if (!isRemoved)
            {
                _logger.LogInformation("[ERROR] Can't delete EncodingType with id {0}", id);
                return NotFound();
            }
            _logger.LogInformation("[SUCCESS] Delete EncodingType with id {0}", id);
            return NoContent();
        }
    }
}
