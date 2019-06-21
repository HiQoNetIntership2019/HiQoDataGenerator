using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Services
{
    public class TimezoneService : IFieldTypeService
    {
        private readonly ITimezoneRepository _timezoneRepostory;

        public TimezoneService(ITimezoneRepository timezoneRepository) => _timezoneRepostory = timezoneRepository;

        public IEnumerable<TimezoneModel> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Timezone, TimezoneModel>()).CreateMapper();
            return mapper.Map<IEnumerable<Timezone>, IEnumerable<TimezoneModel>>(_timezoneRepostory.GetAll());
        }
    }
}
