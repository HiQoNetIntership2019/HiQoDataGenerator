using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Web.ViewModels.Helpers;

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
        public IActionResult Get()
        {
            var constraintsModels = _constraintsService.GetAllAsync();
            var constraintsViewModels = _mapper.Map<IEnumerable<ConstraintViewModel>>(constraintsModels);
            return Ok(constraintsViewModels);
        }

        /// <summary>
        ///     Retrieves constraint with given id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
        public async Task<IActionResult> GetByFieldTypeId(int id)
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
        public async Task<IActionResult> GetByName(string name)
        {
            var constraintModel = await _constraintsService.GetByNameAsync(name);
            return Ok(_mapper.Map<ConstraintViewModel>(constraintModel));
        }

        /// <summary>
        ///     Saves new constraint.
        /// </summary>
        /// <param name="constraintViewModel"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(ConstraintViewModel constraintViewModel)
        {
            var constraintModel = _mapper.Map<ConstraintModel>(constraintViewModel);
            await _constraintsService.AddAsync(constraintModel);
            return Ok(constraintModel);
        }

        /// <summary>
        ///     Saves new available field type for constraint.
        /// </summary>
        /// <param name="viewModel">Complex view model for adding field type.</param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost]
        [Route("AddFieldType")]
        public async Task<IActionResult> AddFieldTypesInConstraint([FromBody] AddFieldTypeInConstraintViewModel viewModel)
        {
            var constraint = _mapper.Map<ConstraintModel>(viewModel.ConstraintViewModel);
            var fieldTypes = _mapper.Map<IEnumerable<FieldTypeModel>>(viewModel.FieldTypeViewModels);
            await _constraintsService.AddFieldTypesForConstraintAsync(constraint, fieldTypes);
            return Ok();
        }

        /// <summary>
        ///     Deletes constraint by its id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _constraintsService.RemoveByIdAsync(id);
            return Ok();
        }
    }
}