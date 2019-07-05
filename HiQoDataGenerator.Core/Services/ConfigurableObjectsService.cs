using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class ConfigurableObjectsService : IConfigurableObjectsService
    {
        private readonly IMapper _mapper;
        private readonly IConfigurableObjectsRepository _configurableObjectsRepository;
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly IConstraintsRepository _constraintsRepository;
        private readonly IUnitOfWork _uow;

        public ConfigurableObjectsService(IUnitOfWork unit, IMapperFactory mapperFactory, 
            IConfigurableObjectsRepository configurableObjectsRepository, IFieldTypeRepository fieldTypeRepository,
            IConstraintsRepository constraintsRepository)
        {
            _uow = unit;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
            _configurableObjectsRepository = configurableObjectsRepository;
            _fieldTypeRepository = fieldTypeRepository;
            _constraintsRepository = constraintsRepository;
        }

        public async Task AddAsync(ConfigurableObjectModel configurableObject)
        {
            var dalConfigurableObject = _mapper.Map<ConfigurableObject>(configurableObject);

            foreach (var field in dalConfigurableObject.Fields)
            {
                await _constraintsRepository.UpdateRangeAsync(field.ConstraintValues.Select(i => i.Constraint));
                await _fieldTypeRepository.UpdateAsync(field.FieldType);
            }
            await _configurableObjectsRepository.AddAsync(dalConfigurableObject);

            await _uow.CommitAsync();
        }

        public IEnumerable<ConfigurableObjectModel> GetAll()
        {
            var allObjects = _configurableObjectsRepository.GetAllWithFields();
            return _mapper.Map<IEnumerable<ConfigurableObjectModel>>(allObjects);
        }

        public IEnumerable<ConfigurableObjectModel> GetByDateCreated(Predicate<DateTime> datePredicate) =>
            _mapper.Map<IEnumerable<ConfigurableObjectModel>>(_configurableObjectsRepository.GetByDateCreation(datePredicate));

        public async Task RemoveById(int id)
        {
            await _configurableObjectsRepository.RemoveByIdAsync(id);
            await _uow.CommitAsync();
        }
    }
}
