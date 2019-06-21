using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IFieldTypeService _fieldTypesService;

        public TypesController(IFieldTypeService fieldTypesService) => _fieldTypesService = fieldTypesService;
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            var types = _fieldTypesService.GetAll();
            return new string[] { types.Count().ToString() };
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<string>> Get(int id)
        {
            var type = await _fieldTypesService.GetById(id);
            if (type == null)
            {
                return NotFound();
            }

            return type.Name;
        }
        
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
