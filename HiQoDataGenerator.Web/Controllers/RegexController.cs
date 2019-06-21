using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using System.Linq;
using AutoMapper;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegexController : ControllerBase
    {
       // private readonly IMapper _mapper;
        private readonly IRegexService _regexService;
        private readonly IMapper _mapper;
        public RegexController(IRegexService regexService)
        {
            this._regexService = regexService;
            //this._mapper = new MapperConfiguration(cfg => cfg.CreateMap<Regex, RegexModel>()).CreateMapper();
        }

        [HttpGet("/index")]
        public IEnumerable<string> Get()
        {
            var regexes = _regexService.GetAll();
            return new string[] { regexes.Count().ToString() };
        }


        [HttpGet("/names")]
        public IEnumerable<string> GetAllNames()
        {
            return _regexService.GetAllNames().ToList();
        }
    }
}
