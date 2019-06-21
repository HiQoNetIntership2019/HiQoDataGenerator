using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using System.Net;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly IFieldTypeService _fieldTypesService;
        private readonly IMapper _mapper;

        public TypesController(IFieldTypeService fieldTypesService,IMapperFactory mapperFactory)
        {
            _fieldTypesService = fieldTypesService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var typeModels = _fieldTypesService.GetAll();
            var typeViewModels = _mapper.Map<IEnumerable<FieldTypeViewModel>>(typeModels);
            return Ok(typeViewModels);
        }
        
        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            var typeModel = await _fieldTypesService.GetByIdAsync(id);
            if (typeModel == null)
            {
                return NotFound();
            }

            var typeViewModel = _mapper.Map<FieldTypeViewModel>(typeModel);
            return Ok(typeViewModel);
        }
        
        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(FieldTypeViewModel typeViewModel)
        {
            var typeModel = _mapper.Map<FieldTypeModel>(typeViewModel);
            var isAdded = await _fieldTypesService.AddAsync(typeModel);

            if (!isAdded)
            {
                return BadRequest();
            }
            return Ok(typeModel);
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
            bool isRemoved = await _fieldTypesService.RemoveByIdAsync(id);
            
            if (!isRemoved)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
