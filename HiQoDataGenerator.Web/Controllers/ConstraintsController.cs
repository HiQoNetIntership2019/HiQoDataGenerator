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

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstraintsController : ControllerBase
    {
        private readonly IConstraintsService _constraintsService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly string _loggerName = "RequestInfoLogger";

        public ConstraintsController(IConstraintsService constraintsService, IMapperFactory mapperFactory, ILoggerFactory loggerFactory)
        {
            _constraintsService = constraintsService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
            _logger = loggerFactory.CreateLogger(_loggerName);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var constraintsModels = _constraintsService.GetAll();
            var constraintsViewModels = _mapper.Map<IEnumerable<ConstraintViewModel>>(constraintsModels);
            _logger.LogInformation("Get all Constraints");
            return Ok(constraintsViewModels);
        }

        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var constraintModel = await _constraintsService.GetByIdAsync(id);
            if (constraintModel == null)
            {
                _logger.LogInformation("Can't get Constraint with id {0} !", id);
                return NotFound();
            }

            var constraintViewModel = _mapper.Map<ConstraintViewModel>(constraintModel);
            _logger.LogInformation("Get Constraint with id {0}", constraintViewModel.Id);
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
                _logger.LogInformation("Can't add Constraint {0}", constraintViewModel.Name);
                return BadRequest();
            }
            _logger.LogInformation("Add Constraint {0}", constraintViewModel.Name);
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
                _logger.LogInformation("Can't delete Constraint with id {0}", id);
                return NotFound();
            }
            _logger.LogInformation("Delete Constraint with id {0}", id);
            return NoContent();
        }
    }
}