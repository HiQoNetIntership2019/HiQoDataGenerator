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
    public class TypesController : ControllerBase
    {
        private readonly IFieldTypeService _fieldTypesService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly string _loggerName = "FieldTypesLogger";

        public TypesController(IFieldTypeService fieldTypesService,IMapperFactory mapperFactory,ILoggerFactory loggerFactory)
        {
            _fieldTypesService = fieldTypesService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
            _logger = loggerFactory.CreateLogger(_loggerName);
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var typeModels = _fieldTypesService.GetAll();
            var typeViewModels = _mapper.Map<IEnumerable<FieldTypeViewModel>>(typeModels);
            _logger.LogInformation("Get all Types");
            return Ok(typeViewModels);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var typeModel = await _fieldTypesService.GetByIdAsync(id);
            if (typeModel == null)
            {
                _logger.LogError("Can't get Type with id {0} !",id);
                return NotFound();
            }

            var typeViewModel = _mapper.Map<FieldTypeViewModel>(typeModel);
            _logger.LogInformation("Get Type with id {0}",typeViewModel.Id);
            return Ok(typeViewModel);
        }
        
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(FieldTypeViewModel typeViewModel)
        {
            var typeModel = _mapper.Map<FieldTypeModel>(typeViewModel);
            var isAdded = await _fieldTypesService.AddAsync(typeModel);

            if (!isAdded)
            {
                _logger.LogError("Can't add Type {0}", typeViewModel.Name);
                return BadRequest();
            }
            _logger.LogInformation("Add Type {0}",typeViewModel.Name);
            return Ok(typeModel);
        }
                
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            bool isRemoved = await _fieldTypesService.RemoveByIdAsync(id);
            
            if (!isRemoved)
            {
                _logger.LogError("Can't delete Type with id {0}", id);
                return NotFound();
            }
            _logger.LogInformation("Delete Type with id {0}", id);
            return NoContent();
        }
    }
}
