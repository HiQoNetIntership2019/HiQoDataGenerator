using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HiQoDataGenerator.Web.Controllers
{
    public class FieldsController : RootController
    {
        private readonly IFieldsService _fieldService;

        public FieldsController(IMapperFactory mapperFactory, IFieldsService fieldService) : base(mapperFactory) =>
            _fieldService = fieldService;

        [HttpGet]
        public IActionResult Get() =>
            Ok(_mapper.Map<IEnumerable<FieldViewModel>>(_fieldService.GetAll()));

        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> Get(int id) =>
            Ok(_mapper.Map<FieldViewModel>(await _fieldService.GetByIdAsync(id)));

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FieldViewModel fieldViewModel)
        {
            await _fieldService.AddAsync(_mapper.Map<FieldModel>(fieldViewModel));
            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _fieldService.RemoveByIdAsync(id);
            return Ok();
        }
    }
}
