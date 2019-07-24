using System.Collections.Generic;
using AutoMapper;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;
using HiQoDataGenerator.Web.Attributes;

namespace HiQoDataGenerator.Web.Controllers
{
    public class EncodingTypeController : RootController
    {
        private readonly IEncodingTypesService _encodingTypesService;

        public EncodingTypeController(IEncodingTypesService encodingTypesService, IMapperFactory mapperFactory) :
            base (mapperFactory) => _encodingTypesService = encodingTypesService;


        /// <summary>
        ///     Gets all encoding types.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet]
        public IActionResult Get()
        {
            var encodingTypeModels = _encodingTypesService.GetAllAsync();
            var encodingTypeViewModels = _mapper.Map<IEnumerable<EncodingTypeViewModel>>(encodingTypeModels);
            return Ok(encodingTypeViewModels);
        }

        /// <summary>
        ///     AGets encoding type by given id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var encodingTypeModel = await _encodingTypesService.GetByIdAsync(id);
            var encodingTypeViewModel = _mapper.Map<EncodingTypeViewModel>(encodingTypeModel);
            return Ok(encodingTypeViewModel);
        }

        /// <summary>
        ///     Adds new encoding type.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost]
        public async Task<IActionResult> Post(EncodingTypeViewModel encodingTypeViewModel)
        {
            var encodingTypeModel = _mapper.Map<EncodingTypeModel>(encodingTypeViewModel);

            await _encodingTypesService.AddAsync(encodingTypeModel);
            return Ok();
        }

        /// <summary>
        ///     Deletes encoding type by id.
        /// </summary>
        /// <returns>Status code 200.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _encodingTypesService.RemoveByIdAsync(id);
            return Ok();
        }
    }
}
