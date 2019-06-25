using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Microsoft.EntityFrameworkCore;


namespace HiQoDataGenerator.Core.Services
{
    public class ConstraintsService : IConstraintsService
    {
        private readonly IConstraintsRepository _constraintsRepository;
        private IMapper _mapper;

        public ConstraintsService(IConstraintsRepository constraintsRepository, IMapperFactory mapperFactory)
        {
            _constraintsRepository = constraintsRepository;
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
                throw new ElementNotFoundException("Can't get Constraint with id " + id.ToString() + "!");
            }
            return  _mapper.Map<ConstraintModel>(constraint);
        }

        public async Task<ConstraintModel> GetByNameAsync(string name)
        {
            var constraint = await _constraintsRepository.GetByNameAsync(name);
            if (constraint == null)
            {
                throw new ElementNotFoundException("Can't get Constraint with name " + name + "!");
            }
            return _mapper.Map<ConstraintModel>(constraint);
        }

        public async Task AddAsync(ConstraintModel constraintModel)
        {
            var constraint = _mapper.Map<Constraint>(constraintModel);
            try
            {
                await _constraintsRepository.AddAsync(constraint);
            }
            catch (DbUpdateException)
            {
                throw new ElementIsAlreadyExistException("Constraint with id " + constraint.Id + " already exists!");
            }
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _constraintsRepository.RemoveByIdAsync(id);
            if (!result)
            {
                throw new ElementNotFoundException("Can't delete Constraint with id " + id.ToString() + "!");
            }
        }
    }
}
