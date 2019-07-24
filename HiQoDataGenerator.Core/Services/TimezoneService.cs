using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class TimezoneService : ITimezonesService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly ITimezoneRepository _timezoneRepostory;

        public TimezoneService(IUnitOfWork unit, ITimezoneRepository timezoneRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _timezoneRepostory = timezoneRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public async Task AddAsync(TimezoneModel model)
        {
            await _timezoneRepostory.AddAsync(_mapper.Map<Timezone>(model));
            await _uow.CommitAsync();
        }
        public async Task RemoveByIdAsync(int id)
        {
            var result = await _timezoneRepostory.RemoveByIdAsync(id);
            if (!result)
            {
                throw new InvalidDataException("Can't delete Timeone with id " + id.ToString() + " !");
            }
            await _uow.CommitAsync();
        }

        public IEnumerable<TimezoneModel> GetAll() => _mapper.Map<IEnumerable<TimezoneModel>>(_timezoneRepostory.GetAllAsync());

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
