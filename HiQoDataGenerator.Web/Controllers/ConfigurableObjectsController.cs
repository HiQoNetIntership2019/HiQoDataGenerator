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


        /// <summary>
        ///     Retrieves all configurable objects.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(_mapper.Map<IEnumerable<ConfigurableObjectViewModel>>(await _configurableObjectsService.GetAllAsync()));

        /// <summary>
        ///     Retrieves all configurable objects created later than given date and time.
        /// </summary>
        /// <param name="date"></param>
        /// <remarks>
        ///     Date example: 2019-07-04T14:26:03.527Z
        /// </remarks>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("datelater/{date}")]
        public async Task<IActionResult> GetByDateLaterAsync(DateTime date) =>
            Ok(_mapper.Map<ConfigurableObjectViewModel>(await _configurableObjectsService.GetByDateCreatedAsync(dateCreated => dateCreated > date)));

        /// <summary>
        ///     Saves a new configurable object.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] ConfigurableObjectViewModel model)
        {
            await _configurableObjectsService.AddAsync(_mapper.Map<ConfigurableObjectModel>(model));

            return Ok();
        }


        /// <summary>
        ///     Deletes a configurable object with given id.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _configurableObjectsService.RemoveById(id);

            return Ok();
        }
        
    }
}
