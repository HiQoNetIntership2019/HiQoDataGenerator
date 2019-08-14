using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using Microsoft.AspNetCore.Http;

namespace HiQoDataGenerator.Web.Controllers
{
    public class RegexController : RootController
    {
       
        private readonly IRegexService _regexService;
     
        public RegexController(IRegexService regexService, IMapperFactory mapperFactory) :
            base(mapperFactory) => _regexService = regexService;

        /// <summary>
        ///    Gets all regexes.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var regexModels = await _regexService.GetAllAsync();
            var regexViewModels = _mapper.Map<IEnumerable<RegexViewModel>>(regexModels);
            return Ok(regexViewModels);
        }

        /// <summary>
        ///     Gets regex by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var regexModel = await _regexService.GetByIdAsync(id);
            var regexViewModel = _mapper.Map<FieldTypeViewModel>(regexModel);
            return Ok(regexViewModel);
        }

        /// <summary>
        ///     Gets all regex names.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet("names")]
        public async Task<IActionResult> GetNamesAsync()
        {
            var models = await _regexService.GetAllNamesAsync();
            return Ok(models);
        }

        /// <summary>
        ///     Adds new regex.
        /// </summary>
        /// <param name="regexViewModel"></param>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(RegexViewModel regexViewModel)
        {
            var regexModel = _mapper.Map<RegexModel>(regexViewModel);

            await _regexService.AddAsync(regexModel);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Deletes regex by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isRemoved = await _regexService.RemoveByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}
