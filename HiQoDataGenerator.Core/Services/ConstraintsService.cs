using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;
using HiQoDataGenerator.DAL.Repositories.EntityFramework;

namespace HiQoDataGenerator.Core.Services
{
    public class ConstraintsService : IConstraintsService
    {
        private readonly IConstraintsRepository _constraintsRepository;
        private readonly IFieldTypesConstraintsRepository _fieldTypesConstraintsRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ConstraintsService(IUnitOfWork unit, IConstraintsRepository constraintsRepository, IMapperFactory mapperFactory,
            IFieldTypesConstraintsRepository fieldTypesConstraintsRepository)
        {
            _constraintsRepository = constraintsRepository;
            _fieldTypesConstraintsRepository = fieldTypesConstraintsRepository;
            _uow = unit;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<ConstraintModel> GetAll()
        {
            var constraints = _constraintsRepository.GetAll();
            return _mapper.Map<IEnumerable<Constraint>, IEnumerable<ConstraintModel>>(constraints);
        }

        public async Task<ConstraintModel> GetByIdAsync(int id)
        {
            var constraint = await _constraintsRepository.GetByIdAsync(id);
            if (constraint == null)
            {
                throw new InvalidDataException("Can't get Constraint with id " + id.ToString() + "!");
            }
            return  _mapper.Map<ConstraintModel>(constraint);
        }

        public async Task<ConstraintModel> GetByNameAsync(string name)
        {
            var constraint = await _constraintsRepository.GetByNameAsync(name);
            if (constraint == null)
            {
                throw new InvalidDataException("Can't get Constraint with name " + name + "!");
            }
            return _mapper.Map<ConstraintModel>(constraint);
        }

        public async Task AddAsync(ConstraintModel constraintModel)
        {
            var constraint = _mapper.Map<Constraint>(constraintModel);
            await _constraintsRepository.AddAsync(constraint);
            await _uow.CommitAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _constraintsRepository.RemoveByIdAsync(id);
            if (!result)
            {
                throw new InvalidDataException("Can't delete Constraint with id " + id.ToString() + "!");
            }
            await _uow.CommitAsync();
        }

        public IEnumerable<ConstraintModel> GetByFieldTypeId(int id)
        {
            var constarints = _constraintsRepository.GetByFieldTypeId(id);
            return _mapper.Map<IEnumerable<ConstraintModel>>(constarints);
        }

        public async Task AddFieldTypesForConstraint(ConstraintModel constraint, IEnumerable<FieldTypeModel> fieldTypes)
        {
            var constraintDalModel = _mapper.Map<Constraint>(constraint);
            foreach (var fieldType in fieldTypes)
            {
                var fieldTypeDalModel = _mapper.Map<FieldType>(fieldType);
                await _fieldTypesConstraintsRepository.AddAsync(new FieldTypeConstraint()
                {
                    Constraint = constraintDalModel,
                    FieldType = fieldTypeDalModel
                });
            }

            await _uow.CommitAsync();
        }
    }
}
