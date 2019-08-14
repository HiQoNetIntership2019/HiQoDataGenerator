using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Web.ViewModels.Helpers;
using Microsoft.AspNetCore.Http;

namespace HiQoDataGenerator.Web.Controllers
{
    public class ConstraintsController : RootController
    {
        private readonly IConstraintsService _constraintsService;
        public ConstraintsController(IConstraintsService constraintsService, IMapperFactory mapperFactory) :
            base(mapperFactory) => _constraintsService = constraintsService;

        /// <summary>
        ///     Retrieves all constraints.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var constraintsModels = await _constraintsService.GetAllAsync();
            var constraintsViewModels = _mapper.Map<IEnumerable<ConstraintViewModel>>(constraintsModels);
            return Ok(constraintsViewModels);
        }

        /// <summary>
        ///     Retrieves constraint with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var constraintModel = await _constraintsService.GetByIdAsync(id);
            var constraintViewModel = _mapper.Map<ConstraintViewModel>(constraintModel);
            return Ok(constraintViewModel);
        }

        /// <summary>
        ///     Retrieves all constraints assignable to specific field type.
        /// </summary>
        /// <param name="id">Field type id.</param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("fieldtype/{id}")]
        public async Task<IActionResult> GetByFieldTypeIdAsync(int id)
        {
            var constraintModels = await _constraintsService.GetByFieldTypeIdAsync(id);
            return Ok(_mapper.Map<IEnumerable<ConstraintViewModel>>(constraintModels));
        }

        /// <summary>
        ///     Retrieves constraint with given name.
        /// </summary>
        /// <param name="name">Name of constraint.</param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetByNameAsync(string name)
        {
            var constraintModel = await _constraintsService.GetByNameAsync(name);
            return Ok(_mapper.Map<ConstraintViewModel>(constraintModel));
        }

        /// <summary>
        ///     Saves new constraint.
        /// </summary>
        /// <param name="constraintViewModel"></param>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(ConstraintViewModel constraintViewModel)
        {
            var constraintModel = _mapper.Map<ConstraintModel>(constraintViewModel);
            await _constraintsService.AddAsync(constraintModel);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Saves new available field type for constraint.
        /// </summary>
        /// <param name="viewModel">Complex view model for adding field type.</param>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [Route("AddFieldType")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddFieldTypesInConstraintAsync([FromBody] AddFieldTypeInConstraintViewModel viewModel)
        {
            var constraint = _mapper.Map<ConstraintModel>(viewModel.ConstraintViewModel);
            var fieldTypes = _mapper.Map<IEnumerable<FieldTypeModel>>(viewModel.FieldTypeViewModels);
            await _constraintsService.AddFieldTypesForConstraintAsync(constraint, fieldTypes);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Deletes constraint by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isRemoved = await _constraintsService.RemoveByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}