using AutoMapper;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggingAttribute))]
    public class RootController : ControllerBase
    {
        protected readonly IMapper _mapper;
        public RootController(IMapperFactory maperFactory) =>
            _mapper = maperFactory.GetMapper(typeof(WebServices).Name);
    }
}
