using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    public class ConfigurableObjectsController : RootController
    {
        private readonly IConfigurableObjectsService _configurableObjectsService;

        public ConfigurableObjectsController(IMapperFactory mapperFactory, IConfigurableObjectsService configurableObjectsService) :
            base(mapperFactory) => _configurableObjectsService = configurableObjectsService;
        

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


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _configurableObjectsService.RemoveById(id);

            return Ok();
        }
        
    }
}
