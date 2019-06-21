using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class TimezoneService : ITimezonesService
    {
        private readonly IMapper _mapperToBusiness;
        private readonly IMapper _mapperFromBusiness;
        private readonly ITimezoneRepository _timezoneRepostory;

        public TimezoneService(ITimezoneRepository timezoneRepository)
        {
            _timezoneRepostory = timezoneRepository;
            _mapperToBusiness = new MapperConfiguration(cfg => cfg.CreateMap<Timezone, TimezoneModel>()).CreateMapper();
            _mapperFromBusiness = new MapperConfiguration(cfg => cfg.CreateMap<TimezoneModel, Timezone>()).CreateMapper();
        }

        public void Add(TimezoneModel model)
        {
            if (model.Value?.Length == 0)
            {
                throw new ArgumentException("value is not be empty");
            }
            _timezoneRepostory.Add(_mapperFromBusiness.Map<TimezoneModel, Timezone>(model));
        }

        public async Task<bool> RemoveById(int id) => await _timezoneRepostory.RemoveById(id);

        public IEnumerable<TimezoneModel> GetAll() 
            => _mapperToBusiness.Map<IEnumerable<Timezone>, IEnumerable<TimezoneModel>>(_timezoneRepostory.GetAll());

        public async Task<TimezoneModel> GetById(int id)
            => _mapperToBusiness.Map<Timezone, TimezoneModel>(await _timezoneRepostory.GetById(id));
    }
}
