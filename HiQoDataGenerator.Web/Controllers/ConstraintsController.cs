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

        [HttpGet]
        [Route("[action]/{name}")]
        public async Task<IActionResult> GetByName(string name)
        {
            var constraintModel = await _constraintsService.GetByNameAsync(name);
            return Ok(_mapper.Map<ConstraintViewModel>(constraintModel));
        }

        [HttpPost]
        public async Task<IActionResult> Post(ConstraintViewModel constraintViewModel)
        {
            var constraintModel = _mapper.Map<ConstraintModel>(constraintViewModel);
            await _constraintsService.AddAsync(constraintModel);
            return Ok(constraintModel);
        }

        [HttpPost]
        [Route("AddFieldType")]
        public async Task<IActionResult> AddFieldTypesInConstraint([FromBody] AddFieldTypeInConstraintViewModel viewModel)
        {
            var constraint = _mapper.Map<ConstraintModel>(viewModel.ConstraintViewModel);
            var fieldTypes = _mapper.Map<IEnumerable<FieldTypeModel>>(viewModel.FieldTypeViewModels);
            await _constraintsService.AddFieldTypesForConstraint(constraint, fieldTypes);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _constraintsService.RemoveByIdAsync(id);
            return Ok();
        }
    }
}