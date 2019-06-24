using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Logging;
using HiQoDataGenerator.Web.ViewModels;
using System.Net;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegexController : ControllerBase
    {
       // private readonly IMapper _mapper;
        private readonly IRegexService _regexService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly string _loggerName = "RequestInfoLogger";

        public RegexController(IRegexService regexService, ILoggerFactory loggerFactory, IMapperFactory mapperFactory)
        {
            this._regexService = regexService;
            this._logger = loggerFactory.CreateLogger(_loggerName);
            this._mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
            //this._mapper = new MapperConfiguration(cfg => cfg.CreateMap<Regex, RegexModel>()).CreateMapper();
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("[GET] Regex");
            var regexModels = _regexService.GetAll();
            var regexViewModels = _mapper.Map<IEnumerable<RegexViewModel>>(regexModels);
            _logger.LogInformation("[SUCCESS] Get all Regexes");
            return Ok(regexViewModels);
        }


        [HttpGet("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation("[GET] by id Regex");
            var regexModel = await _regexService.GetByIdAsync(id);
            if (regexModel == null)
            {
                _logger.LogInformation("[ERROR] Can't get Regex with id {0} !", id);
                return NotFound();
            }

            var regexViewModel = _mapper.Map<FieldTypeViewModel>(regexModel);
            _logger.LogInformation("[SUCCESS] Get Regex with id {0}", regexViewModel.Id);
            return Ok(regexViewModel);
        }

        [HttpGet("names")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public IActionResult GetNames()
        {
            _logger.LogInformation("[GET] Names of Regexes");
            var models = _regexService.GetAllNames();
            if (models == null)
            {
                _logger.LogInformation("[ERROR] Can't any Names");
                return NotFound();
            }
            return Ok(models);
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(RegexViewModel regexViewModel)
        {
            _logger.LogInformation("[POST] Regex");
            var regexModel = _mapper.Map<RegexModel>(regexViewModel);
            var isAdded = await _regexService.AddAsync(regexModel);

            if (!isAdded)
            {
                _logger.LogInformation("[ERROR] Can't add Regex {0}", regexViewModel.Name);
                return BadRequest();
            }
            _logger.LogInformation("[SUCCESS] Add Regex {0}", regexViewModel.Name);
            return Ok(regexModel);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation("[DELETE] Regex");
            bool isRemoved = await _regexService.RemoveByIdAsync(id);

            if (!isRemoved)
            {
                _logger.LogInformation("[ERROR] Can't delete Regex with id {0}", id);
                return NotFound();
            }
            _logger.LogInformation("[SUCCESS] Delete Regex with id {0}", id);
            return NoContent();
        }
    }
}
