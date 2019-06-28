using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DatasetTypesController : RootController
    {
        private readonly IDatasetTypesService _datasetTypesService;

        public DatasetTypesController(IMapperFactory mapperFactory, IDatasetTypesService datasetTypesService) :
            base(mapperFactory) => _datasetTypesService = datasetTypesService;

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
