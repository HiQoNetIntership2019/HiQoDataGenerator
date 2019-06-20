using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Infrastructure;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Services
{
    public class TimezoneService : ITimezonesService
    {
        private readonly ITimezoneRepository _timezoneRepostory;

        public TimezoneService() => _timezoneRepostory = new RepositoryManager().GetTimezoneRepository();

        public IEnumerable<Timezone> GetAll()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<TimezoneModel, Timezone>()).CreateMapper();
            return mapper.Map<IEnumerable<TimezoneModel>, IEnumerable<Timezone>>(_timezoneRepostory.GetAll());
        }
    }
}
