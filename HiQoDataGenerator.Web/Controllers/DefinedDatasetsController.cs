using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.ViewModels.Helpers;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DefinedDatasetsController : RootController
    {
        private readonly IDefinedDatasetService _definedDatasetService;

        public DefinedDatasetsController(IDefinedDatasetService definedDatasetService, IMapperFactory mapperFactory) :
            base(mapperFactory) => _definedDatasetService = definedDatasetService;

        [HttpGet]
        public IActionResult GetAll()
        {
            var definedDatasetModels = _definedDatasetService.GetAll();
            var definedDatasetViewModels = _mapper.Map<IEnumerable<DefinedDatasetViewModel>>(definedDatasetModels);
            return Ok(definedDatasetViewModels);
        }

        [HttpGet]
        [Route("Values")]
        public IActionResult GetValues()
        {
            var definedDatasetValueModels = _definedDatasetService.GetValues();
            var definedDatasetValueViewModels = _mapper.Map<IEnumerable<DefinedDatasetValueViewModel>>(definedDatasetValueModels);
            return Ok(definedDatasetValueViewModels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var definedDatasetModel = await _definedDatasetService.GetByIdAsync(id);
            var definedDatasetViewModel = _mapper.Map<DefinedDatasetViewModel>(definedDatasetModel);
            return Ok(definedDatasetViewModel);
        }

        [HttpGet]
        [Route("Values/ById/{id}")]
        public IActionResult GetValuesByDatasetId(int id)
        {
            var definedDatasetValueModels = _definedDatasetService.GetValuesByDatasetId(id);
            var definedDatasetValueViewModels = _mapper.Map<IEnumerable<DefinedDatasetValueViewModel>>(definedDatasetValueModels);
            return Ok(definedDatasetValueViewModels);
        }

        [HttpGet]
        [Route("Values/ByName/{name}")]
        public IActionResult GetValuesByDatasetName(string name)
        {
            var definedDatasetValueModels = _definedDatasetService.GetValuesByDatasetName(name);
            var definedDatasetValueViewModels = _mapper.Map<IEnumerable<DefinedDatasetValueViewModel>>(definedDatasetValueModels);
            return Ok(definedDatasetValueViewModels);
        }

        [HttpGet]
        [Route("ByTypeId/{id}")]
        public IActionResult GetDatasetsByTypeId(int id)
        {
            var definedDatasetModels = _definedDatasetService.GetDatasetsByTypeId(id);
            var definedDatasetViewModels = _mapper.Map<IEnumerable<DefinedDatasetViewModel>>(definedDatasetModels);
            return Ok(definedDatasetViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddDefinedDatasetWithValues definedDatasetWithValuesViewModel)
        {
            var definedDatasetModel = _mapper.Map<DefinedDatasetModel>(definedDatasetWithValuesViewModel);

            await _definedDatasetService.AddAsync(definedDatasetModel);
            return Ok();
        }

        [HttpPost("Values")]
        public async Task<IActionResult> AddValues(AddDefinedDatasetValues definedDatasetValueViewModels)
        {
            var definedDatasetValueModels = _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValueViewModels.Values);

            await _definedDatasetService.AddValuesAsync(definedDatasetValueModels);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDataset(int id)
        {
            await _definedDatasetService.RemoveDatasetAsync(id);
            return Ok();
        }

        [HttpDelete]
        [Route("Values/{id}")]
        public async Task<IActionResult> DeleteValue(int id)
        {
            await _definedDatasetService.RemoveValueByIdAsync(id);
            return Ok();
        }
    }
}
