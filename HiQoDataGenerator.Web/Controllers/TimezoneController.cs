using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.Controllers
{
    public class TimezoneController : RootController
    {
        private readonly ITimezonesService _timezonesService;
        private readonly IServiceSavingGeneratedObjects _serviceSavingGeneratedObjects;


        public TimezoneController(ITimezonesService timezonesService, IMapperFactory mapperFactory, 
            IServiceSavingGeneratedObjects serviceSavingGeneratedObjects) :
            base(mapperFactory)
        {
            _timezonesService = timezonesService;
            _serviceSavingGeneratedObjects = serviceSavingGeneratedObjects;
        }

        /// <summary>
        ///     Gets all timezones.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public IActionResult Get() => 
            Ok(_mapper.Map<IEnumerable<TimezoneViewModel>>(_timezonesService.GetAll()));


        /// <summary>
        ///     Gets timezone by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var timezone = await _timezonesService.GetByIdAsync(id);
            return Ok(_mapper.Map<TimezoneViewModel>(timezone));
        }

        [HttpGet("test")]
        public async Task<IActionResult> Test()
        {
            _serviceSavingGeneratedObjects.MoveToStorage();
            return Ok();
        }

        /// <summary>
        ///     Saves new timezone.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TimezoneViewModel model)
        {
            await _timezonesService.AddAsync(_mapper.Map<TimezoneModel>(model));
            return Ok();
        }

        /// <summary>
        ///     Deletes timezone by id.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _timezonesService.RemoveByIdAsync(id);
            return Ok();
        } 
    }
}
