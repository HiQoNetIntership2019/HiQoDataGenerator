using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.UnitOfWork;

namespace HiQoDataGenerator.Core.Services
{
    public class DateTimeFormatService : IDateTimeFormatService
    {
        private readonly IDateTimeFormatRepository _dateTimeFormatRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public DateTimeFormatService(IUnitOfWork unit, IDateTimeFormatRepository dateTimeFormatRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _dateTimeFormatRepository = dateTimeFormatRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<DateTimeFormatModel> GetAll()
        {
            var dateTimeFormats = _dateTimeFormatRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DateTimeFormatModel>>(dateTimeFormats);
        }

        public async Task<DateTimeFormatModel> GetByIdAsync(int id)
        {
            var dateTimeFormat = await _dateTimeFormatRepository.GetByIdAsync(id);
            if (dateTimeFormat == null)
            {
                throw new InvalidDataException($"Can't get DateTime format with id {id} !");
            }
            return _mapper.Map<DateTimeFormatModel>(dateTimeFormat);
        }

        public async Task AddAsync(DateTimeFormatModel dateTimeFormatModel)
        {
            var dateTimeFormat = _mapper.Map<DateTimeFormat>(dateTimeFormatModel);
            await _dateTimeFormatRepository.AddAsync(dateTimeFormat);
            await _uow.CommitAsync();
        }

        public async Task AddRangeAsync(IEnumerable<DateTimeFormatModel> dateTimeFormatModels)
        {
            var dateTimeFormats = _mapper.Map<IEnumerable<DateTimeFormat>>(dateTimeFormatModels);
            await _dateTimeFormatRepository.AddRangeAsync(dateTimeFormats);
            await _uow.CommitAsync();
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _dateTimeFormatRepository.RemoveByIdAsync(id);
            if (!result)
            {
                throw new InvalidDataException($"Can't delete DateTime format with id {id} !");
            }
            await _uow.CommitAsync();
        }
    }
}
