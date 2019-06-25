using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.Core.Entities;
using Moq;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class DateTimeFormatTest
    {
        private readonly Mock<IDateTimeFormatRepository> _repositoryMock;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IMapper> _mapperMock;

        private readonly IDateTimeFormatService _dateTimeFormatService;

        public DateTimeFormatTest()
        {
            _mapperMock = new Mock<IMapper>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _repositoryMock = new Mock<IDateTimeFormatRepository>();

            ConfigureMapperMock(_mapperMock);
            _mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapperMock.Object);
            _dateTimeFormatService = new TimezoneService(_repositoryMock.Object, _mapperFactoryMock.Object);
        }

        private void ConfigureMapperMock(Mock<IMapper> mapperMock)
        {
            mapperMock.Setup(mapper => mapper.Map<DateTimeFormat>(null))
        }

        [Fact]
        public async void AddAsyncReturnedTrueIfRepositoryReturnedTrue()
        {
            _repositoryMock.Setup(repository => repository.AddAsync(null)).Returns(async () => true);

            bool isAdded = await _dateTimeFormatService.AddAsync(null);

            Assert.True(isAdded);
        }

        [Fact]
        public async void RemoveByIdReturnedFalseIfRepositoryReturnedFalse()
        {
            const int id = 1;
            _repositoryMock.Setup(repository => repository.RemoveByIdAsync(id)).Returns(async () => false);

            bool isRemoved = await _dateTimeFormatService.RemoveByIdAsync(id);

            Assert.False(isRemoved);
        }
    }
}
