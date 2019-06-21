using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Services
{
    public class FieldTypeService : IFieldTypeService
    {
        private readonly IFieldTypeRepository _fieldTypeRepostory;

        public FieldTypeService(IFieldTypeRepository fieldTypeRepository) => _fieldTypeRepostory = fieldTypeRepository;

        public IEnumerable<FieldTypeModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FieldType, FieldTypeModel>()).CreateMapper();
            return mapper.Map<IEnumerable<FieldType>, IEnumerable<FieldTypeModel>>(_fieldTypeRepostory.GetAll());
        }

        public FieldTypeModel GetById(int id)
        {
            User user = await _repository.GetAsync(id);
        }
    }
}
