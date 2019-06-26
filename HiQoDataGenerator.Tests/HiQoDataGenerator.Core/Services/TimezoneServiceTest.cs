using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Moq;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class TimezoneServiceTest
    {
        private readonly Mock<ITimezoneRepository> _repositoryMock = new Mock<ITimezoneRepository>();
        private readonly Mock<IMapperFactory> _mapperFactoryMock = new Mock<IMapperFactory>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        private readonly ITimezonesService _timezoneService;

        public TimezoneServiceTest()
        {
            _mapperMock.Setup(mapper => mapper.Map<Timezone>(null)).Returns(() => null);
            _mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapperMock.Object);
            _timezoneService = new TimezoneService(_repositoryMock.Object, _mapperFactoryMock.Object);
        }

        [Fact]
        public async void AddAsyncReturnedTrueIfRepositoryReturnedTrue()
        {            
            _repositoryMock.Setup(repository => repository.AddAsync(null)).ReturnsAsync(() => true);

            bool isAdded = await _timezoneService.AddAsync(null);

            Assert.True(isAdded);
        }

        [Fact]
        public async void RemoveByIdReturnedFalseIfRepositoryReturnedFalse()
        {
            const int id = 1;
            _repositoryMock.Setup(repository => repository.RemoveByIdAsync(id)).Returns(async () => false);

            bool isRemoved = await _timezoneService.RemoveByIdAsync(id);

            Assert.False(isRemoved);
        }
    }
}
