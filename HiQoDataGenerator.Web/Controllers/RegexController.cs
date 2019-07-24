using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

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
        public IActionResult Get()
        {
            var regexModels = _regexService.GetAllAsync();
            var regexViewModels = _mapper.Map<IEnumerable<RegexViewModel>>(regexModels);
            return Ok(regexViewModels);
        }

        /// <summary>
        ///     Gets regex by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
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
        public IActionResult GetNames()
        {
            var models = _regexService.GetAllNamesAsync();
            return Ok(models);
        }

        /// <summary>
        ///     Adds new regex.
        /// </summary>
        /// <param name="regexViewModel"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(RegexViewModel regexViewModel)
        {
            var regexModel = _mapper.Map<RegexModel>(regexViewModel);

            await _regexService.AddAsync(regexModel);            
            return Ok();
        }

        /// <summary>
        ///     Deletes regex by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _regexService.RemoveByIdAsync(id);            
            return Ok();
        }
    }
}
