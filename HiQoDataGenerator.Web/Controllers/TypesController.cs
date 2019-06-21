using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
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
        public IActionResult Get()
        {
            var types = _fieldTypesService.GetAll();
            return Ok(types);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var type = await _fieldTypesService.GetById(id);
            if (type == null)
            {
                return NotFound();
            }

            return Ok(type.Name);
        }
        
        [HttpPost]
        public IActionResult Post(FieldTypeViewModel model)
        {
            return Ok(model);
        }
        
        [HttpPut("{id}")]
        public void Put(int id,[FromBody] string value)
        {
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            bool isRemoved = await _fieldTypesService.RemoveById(id);
            
            if (!isRemoved)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
