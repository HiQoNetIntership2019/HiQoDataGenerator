using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : RootController
    {
        private readonly IFieldTypeService _fieldTypesService;

        public TypesController(IFieldTypeService fieldTypesService,IMapperFactory mapperFactory):base(mapperFactory)
        {
            _fieldTypesService = fieldTypesService;
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
            return Ok();
        }
    }
}
