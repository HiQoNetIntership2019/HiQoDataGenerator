using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Services
{
    public class TypesService : IFieldTypesService
    {
        private readonly IFieldTypeRepository _fieldTypeRepostory;

        public TypesService(IFieldTypeRepository fieldTypeRepository) => _fieldTypeRepostory = fieldTypeRepository;

        public IEnumerable<FieldTypeModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<FieldType, FieldTypeModel>()).CreateMapper();
            return mapper.Map<IEnumerable<FieldType>, IEnumerable<FieldTypeModel>>(_fieldTypeRepostory.GetAll());
        }
    }
}
