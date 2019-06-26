using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Moq;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class EncodingTypeServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IEncodingTypeRepository> _repositoryMock;
        private readonly List<EncodingType> _encodingTypes;
        private readonly IEncodingTypesService _encodingTypeService;

        public EncodingTypeServiceTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IEncodingTypeRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _encodingTypes = GenerateEncodingTypes();

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            _encodingTypeService = new EncodingTypeService(_repositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<EncodingType> GenerateEncodingTypes()
        {
            return new List<EncodingType>() { new EncodingType() { Id = 1 }, new EncodingType() { Id = 2 } };
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }

        private void ConfigureRepositoryMock(Mock<IEncodingTypeRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAll()).Returns(_encodingTypes.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _encodingTypes[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);

            repositoryMock.Setup(rep => rep.AddAsync(null)).ReturnsAsync(() => true);

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).ReturnsAsync(() => false);
        }

        [Fact]
        public void GetAll_RightEncodingTypesCount()
        {
            var result = _encodingTypeService.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightEncodingType()
        {
            var result = await _encodingTypeService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _encodingTypeService.GetByIdAsync(3));
        }

        [Fact]
        public void AddAsync_NonExistingElement_NoException()
        {
            var ex = Record.ExceptionAsync(() => _encodingTypeService.AddAsync(null));

            Assert.Null(ex.Result);
        }

        [Fact]
        public void RemoveByIdAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _encodingTypeService.RemoveByIdAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _encodingTypeService.RemoveByIdAsync(3));
        }
    }
}
