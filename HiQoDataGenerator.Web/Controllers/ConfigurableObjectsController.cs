using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.Attributes;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggingAttribute))]
    public class ConfigurableObjectsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IConfigurableObjectsService _configurableObjectsService;

        public ConfigurableObjectsController(IMapperFactory mapperFactory, IConfigurableObjectsService configurableObjectsService)
        {
            _configurableObjectsService = configurableObjectsService;
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
        }

        [HttpGet]
        public IActionResult Get() => Ok(_mapper.Map<IEnumerable<ConfigurableObjectViewModel>>(_configurableObjectsService.GetAll()));

        [HttpGet("datelater/{date}")]
        public IActionResult GetByDateLater(DateTime date) =>
            Ok(_mapper.Map<ConfigurableObjectViewModel>(_configurableObjectsService.GetByDateCreated(dateCreated => dateCreated > date)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ConfigurableObjectViewModel model)
        {
            await _configurableObjectsService.AddAsync(_mapper.Map<ConfigurableObjectModel>(model));

            return Ok();
        }


        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _configurableObjectsService.RemoveById(id);

            return Ok();
        }
        
    }
}
