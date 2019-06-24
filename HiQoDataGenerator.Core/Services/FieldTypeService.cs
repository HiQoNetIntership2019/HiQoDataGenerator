using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.Core.Exceptions;

namespace HiQoDataGenerator.Core.Services
{
    public class FieldTypeService : IFieldTypeService
    {
        private readonly IFieldTypeRepository _fieldTypeRepostory;
        private IMapper _mapper;

        public FieldTypeService(IFieldTypeRepository fieldTypeRepository,IMapperFactory mapperFactory)
        {
            _fieldTypeRepostory = fieldTypeRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<FieldTypeModel> GetAll()
        {
            var types = _fieldTypeRepostory.GetAll();
            return _mapper.Map<IEnumerable<FieldType>, IEnumerable<FieldTypeModel>>(types);
        }

        public async Task<FieldTypeModel> GetByIdAsync(int id)
        {
            var type = await _fieldTypeRepostory.GetByIdAsync(id);
            if (type == null)
            {
                throw new ElementNotFoundException("Can't get Type with id " + id.ToString() + " !");
            }
            return _mapper.Map<FieldTypeModel>(type);
        }

        public async Task AddAsync(FieldTypeModel fieldTypeModel)
        {
            var type = _mapper.Map<FieldType>(fieldTypeModel);
            try
            {
                await _fieldTypeRepostory.AddAsync(type);
            }
            catch (DbUpdateException)
            {
                throw new ElementIsAlreadyExistException("Type with id "+type.Id+" is already exist!");
            }
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _fieldTypeRepostory.RemoveByIdAsync(id);
            if (!result)
            {
                throw new ElementNotFoundException("Can't delete Type with id " + id.ToString() + " !");
            }
        }
    }
}
