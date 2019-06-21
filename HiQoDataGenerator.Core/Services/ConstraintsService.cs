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
        private readonly IMapper _mapper;

        public ConstraintsService(IConstraintsRepository constraintsRepository)
        {
            _constraintsRepository = constraintsRepository;
            _mapper = new MapperConfiguration(cfg => cfg.CreateMap<Constraint, ConstraintModel>()).CreateMapper();
        }

        public IEnumerable<ConstraintModel> GetAll()
        {
            return _mapper.Map<IEnumerable<Constraint>, IEnumerable<ConstraintModel>>(_constraintsRepository.GetAll());
        }

        public async Task<ConstraintModel> GetByName(string name)
        {
            var constraint = await _constraintsRepository.GetByName(name);
            return _mapper.Map<Constraint, ConstraintModel>(constraint);
        }
    }
}
