using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Get()
        {
            var constraintValuesModels = _constraintValuesService.GetAllAsync();
            var constraintValuesViewModels = _mapper.Map<IEnumerable<ConstraintValueViewModel>>(constraintValuesModels);
            return Ok(constraintValuesViewModels);
        }

        /// <summary>
        ///     Retrieves constraint value by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
        public async Task<IActionResult> GetByType(int typeId)
        {
            var constraintValueModels = await _constraintValuesService.GetByTypeAsync(typeId);
            var constraintValueViewModels = _mapper.Map<IEnumerable<ConstraintValueViewModel>>(constraintValueModels);
            return Ok(constraintValueViewModels);
        }

        /// <summary>
        ///     Saves a new constraint value.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(ConstraintValueViewModel constraintValueViewModel)
        {
            var constraintValueModel = _mapper.Map<ConstraintValueModel>(constraintValueViewModel);
            await _constraintValuesService.AddAsync(constraintValueModel);
            return Ok(constraintValueModel);
        }

        /// <summary>
        ///     Removes constraint value.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _constraintValuesService.RemoveByIdAsync(id);
            return Ok();
        }
    }
}