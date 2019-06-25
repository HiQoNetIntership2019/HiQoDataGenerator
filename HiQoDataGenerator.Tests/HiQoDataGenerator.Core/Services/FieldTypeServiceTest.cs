using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.Core.Exceptions;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class FieldTypeServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IFieldTypeRepository> _repositoryMock;
        private readonly List<FieldType> _fieldTypes;
        private readonly IFieldTypeService _fieldTypeService;

        public FieldTypeServiceTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IFieldTypeRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _fieldTypes = GenerateFieldTypes();

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            _fieldTypeService = new FieldTypeService(_repositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<FieldType> GenerateFieldTypes()
        {
            return new List<FieldType>() { new FieldType() { Id = 1 }, new FieldType() { Id = 2 } };
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }

        private void ConfigureRepositoryMock(Mock<IFieldTypeRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAll()).Returns(_fieldTypes.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _fieldTypes[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);

            repositoryMock.Setup(rep => rep.AddAsync(null)).ReturnsAsync(() => true);

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).ReturnsAsync(() => false);
        }

        [Fact]
        public void GetAll_FieldTypesCount()
        {
            var result = _fieldTypeService.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightFieldType()
        {
            var result = await _fieldTypeService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _fieldTypeService.GetByIdAsync(3));
        }

        [Fact]
        public async Task AddAsync_NonExistingElement_NoException()
        {
            var isNotThrown = true;
            try
            {
                await _fieldTypeService.AddAsync(null);
            }
            catch (ElementIsAlreadyExistException)
            {
                isNotThrown = false;
            }
            Assert.True(isNotThrown);
        }

        [Fact]
        public async Task RemoveByIdAsync_ExistingId_NoException()
        {
            var isNotThrown = true;
            try
            {
                await _fieldTypeService.RemoveByIdAsync(1);
            }
            catch (InvalidDataException)
            {
                isNotThrown = false;
            }
            Assert.True(isNotThrown);
        }

        [Fact]
        public async Task RemoveByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _fieldTypeService.RemoveByIdAsync(3));
        }
    }
}
