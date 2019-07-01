using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.Controllers
{
    public class CustomDatasetsController : RootController
    {
        private readonly ICustomDatasetService _customDatasetService;
 
        public CustomDatasetsController(ICustomDatasetService customDatasetService, IMapperFactory mapperFactory) :
            base(mapperFactory) => _customDatasetService = customDatasetService;
         
        
        [HttpGet]
        public IActionResult Get()
        {
            var customDatasetModels = _customDatasetService.GetAll();
            var customDatasetViewModels = _mapper.Map<IEnumerable<CustomDatasetViewModel>>(customDatasetModels);
            return Ok(customDatasetViewModels);
        }
        
        [HttpGet]
        [Route("Values")]
        public IActionResult GetAll()
        {
            var customDatasetValueModels = _customDatasetService.GetAllValues();
            var customDatasetValueViewModels = _mapper.Map<IEnumerable<CustomDatasetValueViewModel>>(customDatasetValueModels);
            return Ok(customDatasetValueViewModels);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customDatasetModel = await _customDatasetService.GetByIdAsync(id);
            var customDatasetViewModel = _mapper.Map<CustomDatasetViewModel>(customDatasetModel);
            return Ok(customDatasetViewModel);
        }
        
        [HttpGet]
        [Route("Values/ById/{id}")]
        public IActionResult GetValuesByDatasetId(int id)
        {
            var customDatasetValueModels = _customDatasetService.GetValuesByDatasetId(id);
            var customDatasetValueViewModels = _mapper.Map<IEnumerable<CustomDatasetValueViewModel>>(customDatasetValueModels);
            return Ok(customDatasetValueViewModels);
        }
               
        [HttpGet]
        [Route("Values/ByName/{name}")]
        public IActionResult GetValuesByDatasetName(string name)
        {
            var customDatasetValueModels = _customDatasetService.GetValuesByDatasetName(name);
            var customDatasetValueViewModels = _mapper.Map<IEnumerable<CustomDatasetValueViewModel>>(customDatasetValueModels);
            return Ok(customDatasetValueViewModels);
        }

        /*[HttpPost]
        public async Task<IActionResult> Post(DateTimeFormatViewModel customDatasetViewModel)
        {
            var dateTimeFormatModel = _mapper.Map<DateTimeFormatModel>(customDatasetViewModel);

            await _customDatasetService.AddAsync(dateTimeFormatModel);
            return Ok();
        }*/

        [HttpPost("Values")]
        public async Task<IActionResult> AddValues(IEnumerable<CustomDatasetValueViewModel> customDatasetValueViewModels)
        {
            var customDatasetValueModels = _mapper.Map<IEnumerable<CustomDatasetValueModel>>(customDatasetValueViewModels);

            await _customDatasetService.AddValuesAsync(customDatasetValueModels);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataset(int id)
        {
            await _customDatasetService.RemoveDatasetAsync(id);
            return Ok();
        }

        [HttpDelete]
        [Route("Values/{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            await _customDatasetService.RemoveValueByIdAsync(id);
            return Ok();
        }
    }
}
