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
        

        [HttpGet]
        public IActionResult Get()
        {
            var regexModels = _regexService.GetAll();
            var regexViewModels = _mapper.Map<IEnumerable<RegexViewModel>>(regexModels);
            return Ok(regexViewModels);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var regexModel = await _regexService.GetByIdAsync(id);
            var regexViewModel = _mapper.Map<FieldTypeViewModel>(regexModel);
            return Ok(regexViewModel);
        }

        [HttpGet("names")]
        public IActionResult GetNames()
        {
            var models = _regexService.GetAllNames();
            return Ok(models);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post(RegexViewModel regexViewModel)
        {
            var regexModel = _mapper.Map<RegexModel>(regexViewModel);

            await _regexService.AddAsync(regexModel);            
            return Ok(regexModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _regexService.RemoveByIdAsync(id);            
            return Ok();
        }
    }
}
