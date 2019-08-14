using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.ViewModels.Helpers;
using Microsoft.AspNetCore.Http;

namespace HiQoDataGenerator.Web.Controllers
{
    public class CustomDatasetsController : RootController
    {
        private readonly ICustomDatasetService _customDatasetService;
        private readonly IDatasetService _datasetService;

        public CustomDatasetsController(ICustomDatasetService customDatasetService, IDatasetService datasetService, IMapperFactory mapperFactory) : base(mapperFactory)
        {
            _customDatasetService = customDatasetService;
            _datasetService = datasetService;
        }

        /// <summary>
        ///     Gets all custom datasets.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var customDatasetModels = await _customDatasetService.GetAllAsync();
            var customDatasetViewModels = _mapper.Map<IEnumerable<CustomDatasetViewModel>>(customDatasetModels);
            return Ok(customDatasetViewModels);
        }

        /// <summary>
        ///     Gets all custom dataset values.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        [Route("Values")]
        public async Task<IActionResult> GetAllAsync()
        {
            var customDatasetValueModels = await _customDatasetService.GetValuesAsync();
            var customDatasetValueViewModels = _mapper.Map<IEnumerable<CustomDatasetValueViewModel>>(customDatasetValueModels);
            return Ok(customDatasetValueViewModels);
        }

        /// <summary>
        ///     Gets custom dataset by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var customDatasetModel = await _customDatasetService.GetByIdAsync(id);
            var customDatasetViewModel = _mapper.Map<CustomDatasetViewModel>(customDatasetModel);
            return Ok(customDatasetViewModel);
        }

        /// <summary>
        ///     Gets values by dataset id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        [Route("Values/ById/{id}")]
        public async Task<IActionResult> GetValuesByDatasetIdAsync(int id)
        {
            var customDatasetValueModels = await _customDatasetService.GetValuesByDatasetIdAsync(id);
            var customDatasetValueViewModels = _mapper.Map<IEnumerable<CustomDatasetValueViewModel>>(customDatasetValueModels);
            return Ok(customDatasetValueViewModels);
        }

        /// <summary>
        ///     Gets values by dataset name.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        [Route("Values/ByName/{name}")]
        public async Task<IActionResult> GetValuesByDatasetNameAsync(string name)
        {
            var customDatasetValueModels = await _customDatasetService.GetValuesByDatasetNameAsync(name);
            var customDatasetValueViewModels = _mapper.Map<IEnumerable<CustomDatasetValueViewModel>>(customDatasetValueModels);
            return Ok(customDatasetValueViewModels);
        }

        /// <summary>
        ///     Saves custom dataset and its values. 
        /// </summary>
        /// <remarks>
        ///     Param is a Complex view model.
        /// </remarks>
        /// <returns>Status code 200.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddDatasetAsync(AddCustomDatasetWithValues customDatasetWithValuesViewModel)
        {
            var customDatasetModel = _mapper.Map<CustomDatasetModel>(customDatasetWithValuesViewModel);

            await _customDatasetService.AddAsync(customDatasetModel);
            return Ok();
        }

        /// <summary>
        ///     Saves custom dataset with values and return id from datasets. 
        /// </summary>
        /// <remarks>
        ///     Param is a Complex view model.
        /// </remarks>
        /// <returns>Status code 201 and id.</returns>
        [HttpPost("withId")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddDatasetAndReturnIdAsync(AddCustomDatasetWithValues customDatasetWithValuesViewModel)
        {
            var customDatasetModel = _mapper.Map<CustomDatasetModel>(customDatasetWithValuesViewModel);
            await _customDatasetService.AddAsync(customDatasetModel);
            var dataset = await _datasetService.GetByNameAsync(customDatasetModel.Name);
            return CreatedAtRoute(RouteData.Values, dataset.Id);
        }

        /// <summary>
        ///     Saves custom dataset values.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost("Values")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddValuesAsync(AddCustomDatasetValues customDatasetValueViewModels)
        {
            var customDatasetValueModels = _mapper.Map<IEnumerable<CustomDatasetValueModel>>(customDatasetValueViewModels.Values);
            await _customDatasetService.AddValuesAsync(customDatasetValueModels);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Deletes dataset by id.
        /// </summary>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteDatasetAsync(int id)
        {
            var isRemoved = await _customDatasetService.RemoveDatasetAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }

        /// <summary>
        ///     Deletes dataset value by id.
        /// </summary>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete]
        [Route("Values/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteValueAsync(int id)
        {
            var isRemoved = await _customDatasetService.RemoveValueByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}
