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
    [Route("api/[controller]")]
    [ApiController]
    public class ConstraintValuesController : ControllerBase
    {
        private readonly IConstraintValuesService _constraintValuesService;
        private readonly IMapper _mapper;

        public ConstraintValuesController(IConstraintValuesService constraintValuesService, IMapperFactory mapperFactory)
        {
            _constraintValuesService = constraintValuesService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }

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
        public async Task<IActionResult> Post(ConstraintViewModel constraintValueViewModel)
        {
            var constraintValueModel = _mapper.Map<ConstraintValueModel>(constraintValueViewModel);
            await _constraintValuesService.AddAsync(constraintValueModel);
            return Ok(constraintValueModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _constraintValuesService.RemoveByIdAsync(id);
            return NoContent();
        }
    }
}