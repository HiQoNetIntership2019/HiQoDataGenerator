using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class TimezoneService : ITimezonesService
    {
        private readonly IMapper _mapper;
        private readonly ITimezoneRepository _timezoneRepostory;

        public TimezoneService(ITimezoneRepository timezoneRepository, IMapperFactory mapperFactory)
        {
            _timezoneRepostory = timezoneRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public async Task AddAsync(TimezoneModel model) => await _timezoneRepostory.AddAsync(_mapper.Map<Timezone>(model));

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _timezoneRepostory.RemoveByIdAsync(id);
            if (!result)
            {
                throw new InvalidDataException("Can't delete Timeone with id " + id.ToString() + " !");
            }
        }

        public IEnumerable<TimezoneModel> GetAll() => _mapper.Map<IEnumerable<TimezoneModel>>(_timezoneRepostory.GetAll());

        public async Task<TimezoneModel> GetByIdAsync(int id) {
            var timezone = await _timezoneRepostory.GetByIdAsync(id);
            if (timezone == null)
            {
                throw new InvalidDataException("Can't get Timezone with id " + id.ToString() + " !");
            }
            return _mapper.Map<TimezoneModel>(timezone);
        }
    }
}
