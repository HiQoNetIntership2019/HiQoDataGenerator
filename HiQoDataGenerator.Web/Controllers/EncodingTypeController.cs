using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncodingTypeController : ControllerBase
    {
        private readonly IEncodingTypesService _encodingTypesService;

        public EncodingTypeController(IEncodingTypesService encodingTypesService) => _encodingTypesService = encodingTypesService;

        [HttpGet ("/index")]
        public IEnumerable<string> Get()
        {
            var encodingTypes = _encodingTypesService.GetAll();
            return new string[] { encodingTypes.Count().ToString() };
        }

       [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            return (await _encodingTypesService.GetByIdAsync(id)).Name;
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
