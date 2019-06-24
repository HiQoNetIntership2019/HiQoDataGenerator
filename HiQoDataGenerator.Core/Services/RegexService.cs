using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class RegexService : IRegexService
    {
        private readonly IRegexRepository _regexRepository;
        private readonly IMapper _mapper;

        public RegexService(IRegexRepository regexRepository, IMapperFactory mapperFactory) {

           _regexRepository = regexRepository;
           _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);           
        }
        public IEnumerable<RegexModel> GetAll()
        {
           return _mapper.Map<IEnumerable<RegexModel>>(_regexRepository.GetAll());
        }

        public IQueryable<string> GetAllNames() =>  _regexRepository.GetAllNames();
 
        
        public async Task<bool> RemoveByIdAsync(int id) => await _regexRepository.RemoveByIdAsync(id);

        public async Task<RegexModel> GetByIdAsync(int id) => _mapper.Map<RegexModel>(await _regexRepository.GetByIdAsync(id));
        public async Task<bool> AddAsync(RegexModel model) => await _regexRepository.AddAsync(_mapper.Map<Regex>(model));

    }
}
