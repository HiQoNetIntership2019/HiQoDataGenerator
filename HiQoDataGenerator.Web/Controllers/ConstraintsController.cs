using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Castle.Core.Logging;
using HiQoDataGenerator.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConstraintsController : ControllerBase
    {
        private readonly IConstraintsService _constraintsService;
        private readonly ILogger _logger;

        public ConstraintsController(IConstraintsService constraintsService, ILoggerFactory loggerFactory)
        {
            _constraintsService = constraintsService;
            _logger = loggerFactory.Create(typeof(ConstraintsController));
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var constraints = _constraintsService.GetAll();
            return constraints.Select(constraint => constraint.Name);
        }

        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return (await _constraintsService.GetByIdAsync(id)).Name;
        }

        [HttpGet("{name}")]
        public async Task<int> Get(string name)
        {
            return (await _constraintsService.GetByNameAsync(name)).Id;
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}