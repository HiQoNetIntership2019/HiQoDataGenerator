using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters.Internal;

namespace HiQoDataGenerator.Web.Controllers
{
    public class ConstraintValuesController : RootController
    {
        private readonly IConstraintValuesService _constraintValuesService;

        public ConstraintValuesController(IConstraintValuesService constraintValuesService, IMapperFactory mapperFactory) :
            base(mapperFactory) => _constraintValuesService = constraintValuesService;


        /// <summary>
        ///     Retrieves all constraint values.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var constraintValuesModels = await _constraintValuesService.GetAllAsync();
            var constraintValuesViewModels = _mapper.Map<IEnumerable<ConstraintValueViewModel>>(constraintValuesModels);
            return Ok(constraintValuesViewModels);
        }

        /// <summary>
        ///     Retrieves constraint value by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var constraintValueModel = await _constraintValuesService.GetByIdAsync(id);
            var constraintValueViewModel = _mapper.Map<ConstraintValueViewModel>(constraintValueModel);
            return Ok(constraintValueViewModel);
        }

        /// <summary>
        ///     Retrieves constraint value by constraint [type] id.
        /// </summary>
        /// <param name="typeId">Id of constraint, which is type for constraint value.</param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        [Route("[action]/{typeId}")]
        public async Task<IActionResult> GetByTypeAsync(int typeId)
        {
            var constraintValueModels = await _constraintValuesService.GetByTypeAsync(typeId);
            var constraintValueViewModels = _mapper.Map<IEnumerable<ConstraintValueViewModel>>(constraintValueModels);
            return Ok(constraintValueViewModels);
        }

        /// <summary>
        ///     Saves a new constraint value.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(ConstraintValueViewModel constraintValueViewModel)
        {
            var constraintValueModel = _mapper.Map<ConstraintValueModel>(constraintValueViewModel);
            await _constraintValuesService.AddAsync(constraintValueModel);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Removes constraint value.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isRemoved = await _constraintValuesService.RemoveByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}