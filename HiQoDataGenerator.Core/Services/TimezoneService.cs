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

        public async Task<bool> AddAsync(TimezoneModel model) => await _timezoneRepostory.AddAsync(_mapper.Map<Timezone>(model));

        public async Task<bool> RemoveByIdAsync(int id) => await _timezoneRepostory.RemoveByIdAsync(id);

        public IEnumerable<TimezoneModel> GetAll() => _mapper.Map<IEnumerable<TimezoneModel>>(_timezoneRepostory.GetAll());

        public async Task<TimezoneModel> GetByIdAsync(int id) => _mapper.Map<TimezoneModel>(await _timezoneRepostory.GetByIdAsync(id));
    }
}
