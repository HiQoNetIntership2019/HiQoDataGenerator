using System.Collections.Generic;
using System.Linq;
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
        private readonly IFieldTypeRepository _fieldTypeRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public ConstraintsService(IUnitOfWork unit, IConstraintsRepository constraintsRepository, IMapperFactory mapperFactory,
            IFieldTypesConstraintsRepository fieldTypesConstraintsRepository, IFieldTypeRepository fieldTypeRepository)
        {
            _constraintsRepository = constraintsRepository;
            _fieldTypesConstraintsRepository = fieldTypesConstraintsRepository;
            _fieldTypeRepository = fieldTypeRepository;
            _uow = unit;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<ConstraintModel> GetAll()
        {
            var constraints = _constraintsRepository.GetAllAsync();
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

        public async Task<IEnumerable<ConstraintModel>> GetByFieldTypeId(int id)
        {
            var constraints = await _constraintsRepository.GetByFieldTypeIdAsync(id);
            return _mapper.Map<IEnumerable<ConstraintModel>>(constraints);
        }

        public async Task AddFieldTypesForConstraint(ConstraintModel constraint, IEnumerable<FieldTypeModel> fieldTypes)
        {
            var constraintDalModel = _mapper.Map<Constraint>(constraint);
            var fieldTypeDalModels = _mapper.Map<IEnumerable<FieldType>>(fieldTypes);
            var fieldTypesConstraintsDalModels = fieldTypeDalModels.Select(item =>
                new FieldTypeConstraint() { Constraint = constraintDalModel, FieldType = item });

            await _fieldTypesConstraintsRepository.AddRangeAsync(fieldTypesConstraintsDalModels);
            await _constraintsRepository.UpdateAsync(constraintDalModel);
            await _fieldTypeRepository.UpdateRangeAsync(fieldTypeDalModels);

            await _uow.CommitAsync();
        }
    }
}
