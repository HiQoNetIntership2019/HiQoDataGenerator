using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.ViewModels.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    public class ConstraintValuesController : RootController
    {
        private readonly IConstraintValuesService _constraintValuesService;

        public ConstraintValuesController(IConstraintValuesService constraintValuesService, IMapperFactory mapperFactory) :
            base(mapperFactory) => _constraintValuesService = constraintValuesService;
        

        [HttpGet]
        public IActionResult Get()
        {
            var constraintValuesModels = _constraintValuesService.GetAll();
            var constraintValuesViewModels = _mapper.Map<IEnumerable<ConstraintValueViewModel>>(constraintValuesModels);
            return Ok(constraintValuesViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var constraintValueModel = await _constraintValuesService.GetByIdAsync(id);
            var constraintValueViewModel = _mapper.Map<ConstraintValueViewModel>(constraintValueModel);
            return Ok(constraintValueViewModel);
        }

        [HttpGet]
        [Route("[action]/{typeId}")]
        public async Task<IActionResult> GetByType(int typeId)
        {
            var constraintValueModels = await _constraintValuesService.GetByTypeAsync(typeId);
            var constraintValueViewModels = _mapper.Map<IEnumerable<ConstraintValueViewModel>>(constraintValueModels);
            return Ok(constraintValueViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConstraintValueViewModel constraintValueViewModel)
        {
            var constraintValueModel = _mapper.Map<ConstraintValueModel>(constraintValueViewModel);
            await _constraintValuesService.AddAsync(constraintValueModel);
            return Ok(constraintValueModel);
        }

        [HttpPost]
        [Route("AddWithConstraintType")]
        public async Task<IActionResult> AddWithConstraintType(AddConstraintWithValue viewModel)
        {
            var constraintValueModel = _mapper.Map<ConstraintValueModel>(viewModel);
            await _constraintValuesService.AddWithTypeAsync(constraintValueModel);
            return Ok(constraintValueModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _constraintValuesService.RemoveByIdAsync(id);
            return Ok();
        }
    }
}