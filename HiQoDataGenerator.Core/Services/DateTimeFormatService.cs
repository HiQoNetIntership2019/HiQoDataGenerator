using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class DateTimeFormatService : IDateTimeFormatService
    {
        private readonly IDateTimeFormatRepository _dateTimeFormatRepository;
        private IMapper _mapper;

        public DateTimeFormatService(IDateTimeFormatRepository dateTimeFormatRepository, IMapperFactory mapperFactory)
        {
            _dateTimeFormatRepository = dateTimeFormatRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<DateTimeFormatModel> GetAll()
        {
            var dateTimeFormats = _dateTimeFormatRepository.GetAll();
            return _mapper.Map<IEnumerable<DateTimeFormatModel>>(dateTimeFormats);
        }

        public async Task<DateTimeFormatModel> GetByIdAsync(int id)
        {
            var dateTimeFormat = await _dateTimeFormatRepository.GetByIdAsync(id);
            if (dateTimeFormat == null)
            {
                return null;
            }
            return _mapper.Map<DateTimeFormatModel>(dateTimeFormat);
        }

        public async Task<bool> AddAsync(DateTimeFormatModel dateTimeFormatModel)
        {
            var dateTimeFormat = _mapper.Map<DateTimeFormat>(dateTimeFormatModel);
            return await _dateTimeFormatRepository.AddAsync(dateTimeFormat);
        }

        public async Task<bool> AddRangeAsync(IEnumerable<DateTimeFormatModel> dateTimeFormatModels)
        {
            var dateTimeFormats = _mapper.Map<IEnumerable<DateTimeFormat>>(dateTimeFormatModels);
            return await _dateTimeFormatRepository.AddRangeAsync(dateTimeFormats);
        }

        public async Task<bool> RemoveByIdAsync(int id)
        {
            return await _dateTimeFormatRepository.RemoveByIdAsync(id);
        }
    }
}
