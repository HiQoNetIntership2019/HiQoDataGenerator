﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.ViewModels.Helpers;
using Microsoft.AspNetCore.Http;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DefinedDatasetsController : RootController
    {
        private readonly IDefinedDatasetService _definedDatasetService;

        public DefinedDatasetsController(IDefinedDatasetService definedDatasetService, IMapperFactory mapperFactory) :
            base(mapperFactory) => _definedDatasetService = definedDatasetService;

        /// <summary>
        ///     Gets all defined datasets.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var definedDatasetModels = await _definedDatasetService.GetAllAsync();
            var definedDatasetViewModels = _mapper.Map<IEnumerable<DefinedDatasetViewModel>>(definedDatasetModels);
            return Ok(definedDatasetViewModels);
        }

        /// <summary>
        ///     Gets all defined values.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Route("Values")]
        public async Task<IActionResult> GetValuesAsync()
        {
            var definedDatasetValueModels = await _definedDatasetService.GetValuesAsync();
            var definedDatasetValueViewModels = _mapper.Map<IEnumerable<DefinedDatasetValueViewModel>>(definedDatasetValueModels);
            return Ok(definedDatasetValueViewModels);
        }

        /// <summary>
        ///     Gets defined dataset by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var definedDatasetModel = await _definedDatasetService.GetByIdAsync(id);
            var definedDatasetViewModel = _mapper.Map<DefinedDatasetViewModel>(definedDatasetModel);
            return Ok(definedDatasetViewModel);
        }

        /// <summary>
        ///     Gets defined value by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        [Route("Values/ById/{id}")]
        public async Task<IActionResult> GetValuesByDatasetIdAsync(int id)
        {
            var definedDatasetValueModels = await _definedDatasetService.GetValuesByDatasetIdAsync(id);
            var definedDatasetValueViewModels = _mapper.Map<IEnumerable<DefinedDatasetValueViewModel>>(definedDatasetValueModels);
            return Ok(definedDatasetValueViewModels);
        }

        /// <summary>
        ///     Gets all defined values by dataset name.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Route("Values/ByName/{name}")]
        public async Task<IActionResult> GetValuesByDatasetNameAsync(string name)
        {
            var definedDatasetValueModels = await _definedDatasetService.GetValuesByDatasetNameAsync(name);
            var definedDatasetValueViewModels = _mapper.Map<IEnumerable<DefinedDatasetValueViewModel>>(definedDatasetValueModels);
            return Ok(definedDatasetValueViewModels);
        }

        /// <summary>
        ///     Gets all datasets by field type id.
        /// </summary>
        /// <returns>Status code 200 and view models.</returns>
        [HttpGet]
        [Route("ByTypeId/{id}")]
        public async Task<IActionResult> GetDatasetsByTypeIdAsync(int id)
        {
            var definedDatasetModels = await _definedDatasetService.GetDatasetsByTypeIdAsync(id);
            var definedDatasetViewModels = _mapper.Map<IEnumerable<DefinedDatasetViewModel>>(definedDatasetModels);
            return Ok(definedDatasetViewModels);
        }

        /// <summary>
        ///     Adds new dataset with values.
        /// </summary>
        /// <remarks>
        ///     Complex model is used as a parameter.
        /// </remarks>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync(AddDefinedDatasetWithValues definedDatasetWithValuesViewModel)
        {
            var definedDatasetModel = _mapper.Map<DefinedDatasetModel>(definedDatasetWithValuesViewModel);

            await _definedDatasetService.AddAsync(definedDatasetModel);
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Adds new values for specific dataset.
        /// </summary>
        /// <remarks>
        ///     Complex model is used as a parameter.
        /// </remarks>
        /// <returns>Status code 201.</returns>
        [HttpPost("Values")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> AddValuesAsync(AddDefinedDatasetValues definedDatasetValueViewModels)
        {
            var definedDatasetValueModels = _mapper.Map<IEnumerable<DefinedDatasetValueModel>>(definedDatasetValueViewModels.Values);

            await _definedDatasetService.AddValuesAsync(definedDatasetValueModels);
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
            var isRemoved = await _definedDatasetService.RemoveDatasetAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }

        /// <summary>
        ///     Deletes defined value by id.
        /// </summary>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete]
        [Route("Values/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteValueAsync(int id)
        {
            var isRemoved = await _definedDatasetService.RemoveValueByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}
