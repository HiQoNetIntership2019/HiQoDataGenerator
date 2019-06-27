using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.Core.Services
{
    public class ConstraintValuesService : IConstraintValuesService
    {
        private readonly IConstraintValuesRepository _constraintValuesRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public ConstraintValuesService(IUnitOfWork unit, IConstraintValuesRepository constraintValuesRepository, IMapperFactory mapperFactory)
        {
            _constraintValuesRepository = constraintValuesRepository;
            _uow = unit;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<ConstraintValueModel> GetAll()
        {
            var constraintValues = _constraintValuesRepository.GetAll();
            return _mapper.Map<IEnumerable<ConstraintValueModel>>(constraintValues);
        }

        public async Task<ConstraintValueModel> GetByIdAsync(int id)
        {
            var constraint = await _constraintValuesRepository.GetByIdAsync(id);
            if (constraint == null)
            {
                throw new InvalidDataException("Can't get Constraint Value with id " + id.ToString() + "!");
            }
            return _mapper.Map<ConstraintValueModel>(constraint);
        }

        public async Task<IEnumerable<ConstraintValueModel>> GetByTypeAsync(int id)
        {
            var constraintValues = await _constraintValuesRepository.GetByTypeAsync(id);
            if (constraintValues == null)
            {
                throw new InvalidDataException("Can't get Constraint Value with Type Id " + id + "!");
            }
            return _mapper.Map<IEnumerable<ConstraintValueModel>>(constraintValues);
        }

        public async Task AddAsync(ConstraintValueModel constraintValueModel)
        {
            var constraint = _mapper.Map<ConstraintValue>(constraintValueModel);
            await _constraintValuesRepository.AddAsync(constraint);
            await _uow.CommitAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _constraintValuesRepository.RemoveByIdAsync(id);
            if (!result)
            {
                throw new InvalidDataException("Can't delete Constraint with id " + id + "!");
            }
            await _uow.CommitAsync();
        }

    }
}
