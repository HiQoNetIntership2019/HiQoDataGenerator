﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace HiQoDataGenerator.Web.Controllers
{

    public class DateTimeFormatsController : RootController
    {
        private readonly IDateTimeFormatService _dateTimeFormatService;
        public DateTimeFormatsController(IDateTimeFormatService dateTimeFormatService, IMapperFactory mapperFactory) : 
            base(mapperFactory) => _dateTimeFormatService = dateTimeFormatService;

        /// <summary>
        ///     Gets all datetime formats.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var dateTimeFormatModels = await _dateTimeFormatService.GetAllAsync();
            var dateTimeFormatViewModels = _mapper.Map<IEnumerable<DateTimeFormatViewModel>>(dateTimeFormatModels);
            return Ok(dateTimeFormatViewModels);
        }

        /// <summary>
        ///     Gets datetime format by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var dateTimeFormatModel = await _dateTimeFormatService.GetByIdAsync(id);
            var dateTimeFormatViewModel = _mapper.Map<DateTimeFormatViewModel>(dateTimeFormatModel);
            return Ok(dateTimeFormatViewModel);
        }

        /// <summary>
        ///     Adds new datetime format.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(DateTimeFormatViewModel dateTimeFormatViewModel)
        {
            var dateTimeFormatModel = _mapper.Map<DateTimeFormatModel>(dateTimeFormatViewModel);

            await _dateTimeFormatService.AddAsync(dateTimeFormatModel);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Adds range of new datetime formats.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Range")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(IEnumerable<DateTimeFormatViewModel> dateTimeFormatViewModels)
        {            
            var dateTimeFormatModels = _mapper.Map<IEnumerable<DateTimeFormatModel>>(dateTimeFormatViewModels);

            await _dateTimeFormatService.AddRangeAsync(dateTimeFormatModels);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Deletes datetime format by id.
        /// </summary>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isRemoved = await _dateTimeFormatService.RemoveByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}
