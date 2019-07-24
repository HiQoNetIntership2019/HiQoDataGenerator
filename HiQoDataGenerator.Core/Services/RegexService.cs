﻿using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.UnitOfWork;

namespace HiQoDataGenerator.Core.Services
{
    public class RegexService : IRegexService
    {
        private readonly IRegexRepository _regexRepository;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public RegexService(IUnitOfWork unit, IRegexRepository regexRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _regexRepository = regexRepository;
           _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);           
        }
        public IEnumerable<RegexModel> GetAll()
        {
           return _mapper.Map<IEnumerable<RegexModel>>(_regexRepository.GetAllAsync());
        }

        public IQueryable<string> GetAllNames() =>  _regexRepository.GetAllNamesAsync();


        public async Task RemoveByIdAsync(int id)
        {
            var result = await _regexRepository.RemoveByIdAsync(id);
            if (!result)
            {
                throw new InvalidDataException("Can't delete Regex with id " + id.ToString() + " !");
            }
            await _uow.CommitAsync();
        }

        public async Task<RegexModel> GetByIdAsync(int id)
        {
            var regex = await _regexRepository.GetByIdAsync(id);
            if (regex == null)
            {
                throw new InvalidDataException("Can't get Regex with id " + id.ToString() + " !");
            }
            return _mapper.Map<RegexModel>(regex);
        }

        public async Task AddAsync(RegexModel model)
        {
            await _regexRepository.AddAsync(_mapper.Map<Regex>(model));
            await _uow.CommitAsync();
        }

    }
}
