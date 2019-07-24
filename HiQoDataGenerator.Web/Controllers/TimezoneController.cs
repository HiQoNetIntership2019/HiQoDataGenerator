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


        public TimezoneController(ITimezonesService timezonesService, IMapperFactory mapperFactory) : 
            base(mapperFactory) => _timezonesService = timezonesService;

        /// <summary>
        ///     Gets all timezones.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync() => 
            Ok(_mapper.Map<IEnumerable<TimezoneViewModel>>(await _timezonesService.GetAllAsync()));


        /// <summary>
        ///     Gets timezone by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var timezone = await _timezonesService.GetByIdAsync(id);
            return Ok(_mapper.Map<TimezoneViewModel>(timezone));
        }

        /// <summary>
        ///     Saves new timezone.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] TimezoneViewModel model)
        {
            await _timezonesService.AddAsync(_mapper.Map<TimezoneModel>(model));
            return Ok();
        }

        /// <summary>
        ///     Deletes timezone by id.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _timezonesService.RemoveByIdAsync(id);
            return Ok();
        } 
    }
}
