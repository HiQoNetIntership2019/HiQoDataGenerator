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

        /// <summary>
        ///     Gets all field types.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var typeModels = _fieldTypesService.GetAll();
            var typeViewModels = _mapper.Map<IEnumerable<FieldTypeViewModel>>(typeModels);
            return Ok(typeViewModels);
        }

        /// <summary>
        ///     Gets field type by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var typeModel = await _fieldTypesService.GetByIdAsync(id);
            var typeViewModel = _mapper.Map<FieldTypeViewModel>(typeModel);
            return Ok(typeViewModel);
        }

        /// <summary>
        ///     Adds new field type.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(FieldTypeViewModel typeViewModel)
        {
            var typeModel = _mapper.Map<FieldTypeModel>(typeViewModel);

            await _fieldTypesService.AddAsync(typeModel);
            return Ok(typeModel);
        }

        /// <summary>
        ///     Deletes field type by id.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fieldTypesService.RemoveByIdAsync(id);          
            return Ok();
        }
    }
}
