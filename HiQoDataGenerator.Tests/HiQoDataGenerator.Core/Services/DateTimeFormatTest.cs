using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.Core.Exceptions;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class DateTimeFormatTest
    {       
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IDateTimeFormatRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly List<DateTimeFormat> _dateTimeFormats;
        private readonly IDateTimeFormatService _dateTimeFormatService;

        public DateTimeFormatTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IDateTimeFormatRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _dateTimeFormats = GenerateDateTimeFormats();

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            ConfigureUOWMock(_unitOfWorkMock);
            _dateTimeFormatService = new DateTimeFormatService(_unitOfWorkMock.Object, _repositoryMock.Object, _mapperFactoryMock.Object);
        }
        
        private List<DateTimeFormat> GenerateDateTimeFormats()
        {
            return new List<DateTimeFormat>() { new DateTimeFormat() { Id = 1 }, new DateTimeFormat() { Id = 2 } };
        }

        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {
            uowMock.Setup(uow => uow.CommitAsync());
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }
        
        private void ConfigureRepositoryMock(Mock<IDateTimeFormatRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAll()).Returns(_dateTimeFormats.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _dateTimeFormats[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);

            repositoryMock.Setup(rep => rep.AddAsync(null));

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).ReturnsAsync(() => false);
        }

        [Fact]
        public void GetAll_RightDateTimeFromatsCount()
        {
            var result = _dateTimeFormatService.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightDateTimeFromat()
        {
            var result = await _dateTimeFormatService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _dateTimeFormatService.GetByIdAsync(3));
        }

        [Fact]
        public void AddAsync_NonExistingElement_NoException()
        {
            var ex = Record.ExceptionAsync(() => _dateTimeFormatService.AddAsync(null));

            Assert.Null(ex.Result);
        }

        [Fact]
        public void RemoveByIdAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _dateTimeFormatService.RemoveByIdAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _dateTimeFormatService.RemoveByIdAsync(3));
        }
    }
}
