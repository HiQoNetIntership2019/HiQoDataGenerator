using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.WireProtocol.Messages;

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
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] ConfigurableObjectViewModel model)
        {
            await _configurableObjectsService.AddAsync(_mapper.Map<ConfigurableObjectModel>(model));
            
            return StatusCode(StatusCodes.Status201Created);
        }


        /// <summary>
        ///     Deletes a configurable object with given id.
        /// </summary>
        /// <returns>Status code 200 or 208, depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isRemoved = await _configurableObjectsService.RemoveById(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
        
    }
}
