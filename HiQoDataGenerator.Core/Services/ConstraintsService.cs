using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;


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
                return null;
            }
            return  _mapper.Map<ConstraintModel>(constraint);
        }

        public async Task<ConstraintModel> GetByNameAsync(string name)
        {
            var constraint = await _constraintsRepository.GetByNameAsync(name);
            if (constraint == null)
            {
                return null;
            }
            return _mapper.Map<ConstraintModel>(constraint);
        }

        public async Task<bool> AddAsync(ConstraintModel constraintModel)
        {
            var constraint = _mapper.Map<Constraint>(constraintModel);
            return await _constraintsRepository.AddAsync(constraint);
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            return await _constraintsRepository.RemoveByIdAsync(id);
        }
    }
}
