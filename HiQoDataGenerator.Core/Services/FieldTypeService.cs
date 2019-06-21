using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class FieldTypeService : IFieldTypeService
    {
        private readonly IFieldTypeRepository _fieldTypeRepostory;
        private IMapper _mapper;

        public FieldTypeService(IFieldTypeRepository fieldTypeRepository)
        {
            _fieldTypeRepostory = fieldTypeRepository;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<FieldType, FieldTypeModel>()).CreateMapper();
        }

        public IEnumerable<FieldTypeModel> GetAll()
        {
            var types = _fieldTypeRepostory.GetAll();
            return _mapper.Map<IEnumerable<FieldType>, IEnumerable<FieldTypeModel>>(types);
        }

        public async Task<FieldTypeModel> GetById(int id)
        {
            var type = await _fieldTypeRepostory.GetById(id);
            if (type == null)
            {
                return null;
            }
            return _mapper.Map<FieldTypeModel>(type);
        }

        public async Task<bool> Add(FieldTypeModel fieldTypeModel)
        {
            var type = _mapper.Map<FieldType>(fieldTypeModel);
            return await _fieldTypeRepostory.Add(type);
        }

        public async Task<bool> RemoveById(int id)
        {
            return await _fieldTypeRepostory.RemoveById(id);
        }
    }
}
