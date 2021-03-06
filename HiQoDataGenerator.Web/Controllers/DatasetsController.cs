﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DatasetsController : RootController
    {
        private readonly IDatasetService _datasetService;

        public DatasetsController(IDatasetService datasetService, IMapperFactory mapperFactory) :
            base(mapperFactory) => _datasetService = datasetService;

        /// <summary>
        ///     Gets all datasets.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var datasetModels = await _datasetService.GetAllAsync();
            var datasetViewModels = _mapper.Map<IEnumerable<DatasetViewModel>>(datasetModels);
            return Ok(datasetViewModels);
        }

        /// <summary>
        ///     Gets dataset by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var datasetModel = await _datasetService.GetByIdAsync(id);
            var datasetViewModel = _mapper.Map<DatasetViewModel>(datasetModel);
            return Ok(datasetViewModel);
        }

        /// <summary>
        ///     Gets values by dataset id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        [Route("Values/ById/{id}")]
        public async Task<IActionResult> GetValuesByDatasetIdAsync(int id)
        {
            var datasetValueModels = await _datasetService.GetValuesByDatasetIdAsync(id);
            var datasetValueViewModels = _mapper.Map<IEnumerable<DatasetValueViewModel>>(datasetValueModels);
            return Ok(datasetValueViewModels);
        }

        /// <summary>
        ///     Gets values by dataset name.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Route("Values/ByName/{name}")]
        public async Task<IActionResult> GetValuesByDatasetNameAsync(string name)
        {
            var datasetValueModels = await _datasetService.GetValuesByDatasetNameAsync(name);
            var datasetValueViewModels = _mapper.Map<IEnumerable<DatasetValueViewModel>>(datasetValueModels);
            return Ok(datasetValueViewModels);
        }

        /// <summary>
        ///     Gets all datasets by field type id.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Route("ByTypeId/{id}")]
        public async Task<IActionResult> GetDatasetsByTypeIdAsync(int id)
        {
            var datasetModels = await _datasetService.GetDatasetsByTypeIdAsync(id);
            var datasetViewModels = _mapper.Map<IEnumerable<DatasetViewModel>>(datasetModels);
            return Ok(datasetViewModels);
        }

        /// <summary>
        ///     Convert defined dataset to custom
        /// </summary>
        /// <returns>Status code 200</returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> ToDefinedDatasetAsync(int id)
        {
            await _datasetService.ToDefinedDatasetAsync(id);
            return Ok();
        }
    }
}
