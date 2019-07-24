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
using HiQoDataGenerator.Core.UnitOfWork;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class FieldTypeServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IFieldTypeRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly List<FieldType> _fieldTypes;
        private readonly IFieldTypeService _fieldTypeService;

        public FieldTypeServiceTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IFieldTypeRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _fieldTypes = GenerateFieldTypes();

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            ConfigureUOWMock(_unitOfWorkMock);
            _fieldTypeService = new FieldTypeService(_unitOfWorkMock.Object, _repositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<FieldType> GenerateFieldTypes()
        {
            return new List<FieldType>() { new FieldType() { Id = 1 }, new FieldType() { Id = 2 } };
        }

        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {
            uowMock.Setup(uow => uow.CommitAsync());
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }

        private void ConfigureRepositoryMock(Mock<IFieldTypeRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAllAsync()).Returns(_fieldTypes.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _fieldTypes[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);

            repositoryMock.Setup(rep => rep.AddAsync(null));

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).ReturnsAsync(() => false);
        }

        [Fact]
        public void GetAll_FieldTypesCount()
        {
            var result = _fieldTypeService.GetAllAsync();

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
        public void RemoveByIdAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _fieldTypeService.RemoveByIdAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _fieldTypeService.RemoveByIdAsync(3));
        }
    }
}
