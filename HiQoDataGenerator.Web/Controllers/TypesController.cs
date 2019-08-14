using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Http;

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
        public async Task<IActionResult> GetAsync()
        {
            var typeModels = await _fieldTypesService.GetAllAsync();
            var typeViewModels = _mapper.Map<IEnumerable<FieldTypeViewModel>>(typeModels);
            return Ok(typeViewModels);
        }

        /// <summary>
        ///     Gets field type by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var typeModel = await _fieldTypesService.GetByIdAsync(id);
            var typeViewModel = _mapper.Map<FieldTypeViewModel>(typeModel);
            return Ok(typeViewModel);
        }

        /// <summary>
        ///     Gets supported types
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        [Route("SupportedTypes")]
        public async Task<IActionResult> GetSupportedTypesAsync()
        {
            var result = await _fieldTypesService.GetSupportedTypesAsync();
            return Ok(result);
        }

        /// <summary>
        ///     Adds new field type.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(FieldTypeViewModel typeViewModel)
        {
            var typeModel = _mapper.Map<FieldTypeModel>(typeViewModel);

            await _fieldTypesService.AddAsync(typeModel);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Deletes field type by id.
        /// </summary>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isRemoved = await _fieldTypesService.RemoveByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}
