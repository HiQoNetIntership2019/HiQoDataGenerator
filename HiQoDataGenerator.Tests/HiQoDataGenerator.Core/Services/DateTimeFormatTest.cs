using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.Core.Entities;
using System;
using System.Linq;
using Moq;
using Xunit;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class DateTimeFormatTest
    {       
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IDateTimeFormatRepository> _repositoryMock;
        private readonly List<DateTimeFormat> _dateTimeFormats;
        private readonly IDateTimeFormatService _dateTimeFormatService;

        public DateTimeFormatTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IDateTimeFormatRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _dateTimeFormats = GenerateDateTimeFormats();

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            _dateTimeFormatService = new DateTimeFormatService(_repositoryMock.Object, _mapperFactoryMock.Object);
        }
        
        private List<DateTimeFormat> GenerateDateTimeFormats()
        {
            return new List<DateTimeFormat>() { new DateTimeFormat() { Id = 1 }, new DateTimeFormat() { Id = 2 } };
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }

        private void ConfigureRepositoryMock(Mock<IDateTimeFormatRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAll()).Returns(_dateTimeFormats.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).Returns(async () => _dateTimeFormats[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).Returns(async () => null);

            repositoryMock.Setup(rep => rep.AddAsync(null)).Returns(async () => true);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).Returns(async () => throw new DbUpdateException("error",new Exception()));

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).Returns(async () => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).Returns(async () => false);
        }

        [Fact]
        public void DateTimeFormatService_GetAll_RightDateTimeFromatsCount()
        {
            var result = _dateTimeFormatService.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void DateTimeFormatService_GetById_RightDateTimeFromat()
        {
            var result = await _dateTimeFormatService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }
    }
}
