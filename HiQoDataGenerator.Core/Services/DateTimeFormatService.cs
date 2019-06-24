using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;

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
                throw new ElementNotFoundException("Can't get DateTime format with id "+id.ToString()+" !");
            }
            return _mapper.Map<DateTimeFormatModel>(dateTimeFormat);
        }

        public async Task AddAsync(DateTimeFormatModel dateTimeFormatModel)
        {
            var dateTimeFormat = _mapper.Map<DateTimeFormat>(dateTimeFormatModel);
            try
            {
                await _dateTimeFormatRepository.AddAsync(dateTimeFormat);
            }
            catch (DbUpdateException)
            {
                throw new ElementIsAlreadyExistException();
            }
        }

        public async Task AddRangeAsync(IEnumerable<DateTimeFormatModel> dateTimeFormatModels)
        {
            var dateTimeFormats = _mapper.Map<IEnumerable<DateTimeFormat>>(dateTimeFormatModels);
            try
            {
                await _dateTimeFormatRepository.AddRangeAsync(dateTimeFormats);
            }
            catch (DbUpdateException)
            {
                throw new ElementIsAlreadyExistException();
            }
        }

        public async Task RemoveByIdAsync(int id)
        {
            var result = await _dateTimeFormatRepository.RemoveByIdAsync(id);
            if (!result)
            {
                throw new ElementNotFoundException("Can't delete DateTime format with id "+id.ToString()+" !");
            }
        }
    }
}
