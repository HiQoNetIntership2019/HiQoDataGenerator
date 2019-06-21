using System;
using System.Collections.Generic;
using System.Text;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using AutoMapper;
using System.Threading.Tasks;
using System.Linq;

namespace HiQoDataGenerator.Core.Services
{
    public class RegexService : IRegexService
    {

        private readonly IRegexRepository _regexRepository;
        private readonly IMapper mapper;

        public RegexService(IRegexRepository regexRepository) {

           this._regexRepository = regexRepository;
           mapper = new MapperConfiguration(cfg => cfg.CreateMap<Regex, RegexModel>()).CreateMapper();
        }
        public IEnumerable<RegexModel> GetAll()
        {
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Regex, RegexModel>()).CreateMapper();
            return mapper.Map<IEnumerable<Regex>, IEnumerable<RegexModel>>(_regexRepository.GetAll());
        }

        public IQueryable<string> GetAllNames()
        {
            return _regexRepository.GetAllNames();
        }
    }
}
