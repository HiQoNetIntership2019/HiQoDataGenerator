using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using Microsoft.Extensions.Logging;
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
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var constraintModel = await _constraintsService.GetByIdAsync(id);
            if (constraintModel == null)
            {
                return NotFound();
            }

            var constraintViewModel = _mapper.Map<ConstraintViewModel>(constraintModel);
            return Ok(constraintViewModel);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(ConstraintViewModel constraintViewModel)
        {
            var constraintModel = _mapper.Map<ConstraintModel>(constraintViewModel);
            var isAdded = await _constraintsService.AddAsync(constraintModel);

            if (!isAdded)
            {
                return BadRequest();
            }
            return Ok(constraintModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            bool isRemoved = await _constraintsService.RemoveByIdAsync(id);

            if (!isRemoved)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}