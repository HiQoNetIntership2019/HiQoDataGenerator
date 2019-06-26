using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.Attributes;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(LoggingAttribute))]
    public class DatasetTypesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IDatasetTypesService _datasetTypesService;

        public DatasetTypesController(IMapperFactory mapperFactory, IDatasetTypesService datasetTypesService)
        {
            _mapper = mapperFactory.GetMapper(typeof(WebServices).Name);
            _datasetTypesService = datasetTypesService;
        }

        [HttpGet]
        public IActionResult Get() => Ok(_mapper.Map<IEnumerable<DatasetTypeViewModel>>(_datasetTypesService.GetAllTypes()));


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string value)
        {
            await _datasetTypesService.AddTypeAsync(_mapper.Map<DatasetTypeModel>(new DatasetTypeViewModel() { TypeName = value }));
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _datasetTypesService.RemoveById(id);
            return Ok();
        }
    }
}
