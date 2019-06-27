using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Web.Attributes;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggingAttribute))]
    public class ConstraintsController : ControllerBase
    {
        private readonly IConstraintsService _constraintsService;
        private readonly IMapper _mapper;

        public ConstraintsController(IConstraintsService constraintsService, IMapperFactory mapperFactory)
        {
            _constraintsService = constraintsService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var constraintsModels = _constraintsService.GetAll();
            var constraintsViewModels = _mapper.Map<IEnumerable<ConstraintViewModel>>(constraintsModels);
            return Ok(constraintsViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var constraintModel = await _constraintsService.GetByIdAsync(id);
            var constraintViewModel = _mapper.Map<ConstraintViewModel>(constraintModel);
            return Ok(constraintViewModel);
        }

        [HttpGet("fieldtype/{id}")]
        public IActionResult GetByFieldTypeId(int id)
        {
            var constraintModels = _constraintsService.GetByFieldTypeId(id);
            return Ok(_mapper.Map<IEnumerable<ConstraintViewModel>>(constraintModels));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConstraintViewModel constraintViewModel)
        {
            var constraintModel = _mapper.Map<ConstraintModel>(constraintViewModel);
            await _constraintsService.AddAsync(constraintModel);
            return Ok(constraintModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddFieldTypesInConstraint([FromBody] (ConstraintViewModel constraintViewModel, 
            IEnumerable<FieldTypeViewModel> fieldTypeViewModels) body)
        {
            var constraint = _mapper.Map<ConstraintModel>(body.constraintViewModel);
            var fieldTypes = _mapper.Map<IEnumerable<FieldTypeModel>>(body.fieldTypeViewModels);
            await _constraintsService.AddFieldTypesForConstraint(constraint, fieldTypes);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _constraintsService.RemoveByIdAsync(id);
            return NoContent();
        }
    }
}