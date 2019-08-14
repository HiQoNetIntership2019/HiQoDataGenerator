using AutoMapper;
using System;
using System.Linq;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Restrictions;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.UnitOfWork;

namespace HiQoDataGenerator.Core.Services
{
    public class FieldTypeService : IFieldTypeService
    {
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public FieldTypeService(IUnitOfWork unit, IFieldTypeRepository fieldTypeRepository,IMapperFactory mapperFactory)
        {
            _uow = unit;
            _fieldTypeRepository = fieldTypeRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public async Task<IEnumerable<string>> GetSupportedTypesAsync()
        {
            return await Task.Run(()=>Enum.GetNames(typeof(SupportedTypes)));
        }

        public async Task<IEnumerable<FieldTypeModel>> GetAllAsync()
        {
            var types = await _fieldTypeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FieldType>, IEnumerable<FieldTypeModel>>(types);
        }

        public async Task<FieldTypeModel> GetByIdAsync(int id)
        {
            var type = await _fieldTypeRepository.GetByIdAsync(id);
            if (type == null)
            {
                throw new InvalidDataException($"Can't get Type with id {id} !");
            }
            return _mapper.Map<FieldTypeModel>(type);
        }

        public async Task AddAsync(FieldTypeModel fieldTypeModel)
        {
            var type = _mapper.Map<FieldType>(fieldTypeModel);
            var supportedType = Enum.GetNames(typeof(SupportedTypes)).Where(item => item.ToLower() == type.Name.ToLower()).FirstOrDefault();

            type.Name = supportedType ?? throw new InvalidDataException($"Type <{type.Name}> is not supported!");
            await _fieldTypeRepository.AddAsync(type);
            await _uow.CommitAsync();
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var result = await _fieldTypeRepository.RemoveByIdAsync(id);
            await _uow.CommitAsync();
            return result;
        }
    }
}
