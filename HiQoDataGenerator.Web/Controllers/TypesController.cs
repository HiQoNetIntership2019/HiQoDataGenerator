using System.Collections.Generic;
using AutoMapper;
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
    public class TypesController : ControllerBase
    {
        private readonly IFieldTypeService _fieldTypesService;
        private readonly IMapper _mapper;

        public TypesController(IFieldTypeService fieldTypesService,IMapperFactory mapperFactory)
        {
            _fieldTypesService = fieldTypesService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var typeModels = _fieldTypesService.GetAll();
            var typeViewModels = _mapper.Map<IEnumerable<FieldTypeViewModel>>(typeModels);
            return Ok(typeViewModels);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var typeModel = await _fieldTypesService.GetByIdAsync(id);
            var typeViewModel = _mapper.Map<FieldTypeViewModel>(typeModel);
            return Ok(typeViewModel);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(FieldTypeViewModel typeViewModel)
        {
            var typeModel = _mapper.Map<FieldTypeModel>(typeViewModel);

            await _fieldTypesService.AddAsync(typeModel);
            return Ok(typeModel);
        }
                
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fieldTypesService.RemoveByIdAsync(id);          
            return NoContent();
        }
    }
}
