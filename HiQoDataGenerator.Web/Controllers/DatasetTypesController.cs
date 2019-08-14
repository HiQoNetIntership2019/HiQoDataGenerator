using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    public class DatasetTypesController : RootController
    {
        private readonly IDatasetTypesService _datasetTypesService;

        public DatasetTypesController(IMapperFactory mapperFactory, IDatasetTypesService datasetTypesService) :
            base(mapperFactory) => _datasetTypesService = datasetTypesService;

        /// <summary>
        ///     Gets all dataset values.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync() => Ok(_mapper.Map<IEnumerable<DatasetTypeViewModel>>(await _datasetTypesService.GetAllTypesAsync()));

        /// <summary>
        ///     Saves new dataset type.
        /// </summary>
        /// <returns>Status code 201.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> PostAsync([FromBody] string value)
        {
            await _datasetTypesService.AddTypeAsync(_mapper.Map<DatasetTypeModel>(new DatasetTypeViewModel() { TypeName = value }));
            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Deletes dataset type.
        /// </summary>
        /// <returns>Status code 200 or 204 depending on removal result.</returns>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isRemoved = await _datasetTypesService.RemoveByIdAsync(id);
            var httpResult = isRemoved ? Ok() : StatusCode(StatusCodes.Status204NoContent);
            return httpResult;
        }
    }
}
