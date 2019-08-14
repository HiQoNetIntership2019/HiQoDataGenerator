using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    public class FieldsController : RootController
    {
        private readonly IFieldsService _fieldService;

        public FieldsController(IMapperFactory mapperFactory, IFieldsService fieldService) : base(mapperFactory) =>
            _fieldService = fieldService;

        /// <summary>
        ///     Gets all fields.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync() =>
            Ok(_mapper.Map<IEnumerable<FieldViewModel>>(await _fieldService.GetAllAsync()));

        /// <summary>
        ///     Gets field by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id) =>
            Ok(_mapper.Map<FieldViewModel>(await _fieldService.GetByIdAsync(id)));

        /// <summary>
        ///     Adds new field.
        /// </summary>
        /// <param name="fieldViewModel">Field for adding.</param>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] FieldViewModel fieldViewModel)
        {
            await _fieldService.AddAsync(_mapper.Map<FieldModel>(fieldViewModel));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Deletes a field by id.
        /// </summary>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isRemoved = await _fieldService.RemoveByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}
