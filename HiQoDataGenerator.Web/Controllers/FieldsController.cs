using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
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
        public IActionResult Get() =>
            Ok(_mapper.Map<IEnumerable<FieldViewModel>>(_fieldService.GetAllAsync()));

        /// <summary>
        ///     Gets field by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id) =>
            Ok(_mapper.Map<FieldViewModel>(await _fieldService.GetByIdAsync(id)));

        /// <summary>
        ///     Adds new field.
        /// </summary>
        /// <param name="fieldViewModel">Field for adding.</param>
        /// <returns>Status code 200.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FieldViewModel fieldViewModel)
        {
            await _fieldService.AddAsync(_mapper.Map<FieldModel>(fieldViewModel));
            return Ok();
        }

        /// <summary>
        ///     Deletes a field by id.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fieldService.RemoveByIdAsync(id);
            return Ok();
        }
    }
}
