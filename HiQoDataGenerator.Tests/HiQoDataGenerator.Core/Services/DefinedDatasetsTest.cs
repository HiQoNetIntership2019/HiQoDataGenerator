using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.Core.Exceptions;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class DefinedDatasetsTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IDefinedDatasetRepository> _repositoryMock;
        private readonly Mock<IDatasetRepository> _datasetRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly List<DefinedDataset> _definedDatasets;
        private readonly List<DefinedDatasetValue> _definedDatasetValues;
        private readonly IDefinedDatasetService _definedDatasetService;

        public DefinedDatasetsTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IDefinedDatasetRepository>();
            _datasetRepositoryMock = new Mock<IDatasetRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _definedDatasets = GenerateCustomDatasets();
            _definedDatasetValues = GenerateDefinedDatasetValues(_definedDatasets);

            ConfigureDefinedDatasetRepositoryMock(_repositoryMock);
            ConfigureDatasetRepositoryMock(_datasetRepositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            ConfigureUOWMock(_unitOfWorkMock);
            _definedDatasetService = new DefinedDatasetService(_unitOfWorkMock.Object, _repositoryMock.Object, _datasetRepositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<DefinedDataset> GenerateCustomDatasets()
        {
            return new List<DefinedDataset>() { new DefinedDataset() { Id = 1, Name = "Cities", TypeId = 1 }, new DefinedDataset() { Id = 2, Name = "Books", TypeId = 2 } };
        }

        private List<DefinedDatasetValue> GenerateDefinedDatasetValues(List<DefinedDataset> definedDatasets)
        {
            return new List<DefinedDatasetValue>() { new DefinedDatasetValue() { Id = 1, Value = "City1", Dataset = definedDatasets[0] },
                                                    new DefinedDatasetValue() { Id = 2, Value = "City2", Dataset = definedDatasets[0] },
                                                    new DefinedDatasetValue() { Id = 3, Value = "Book1", Dataset = definedDatasets[1] },
                                                    new DefinedDatasetValue() { Id = 4, Value = "Book2", Dataset = definedDatasets[1] }
            };
        }

        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {
            uowMock.Setup(uow => uow.CommitAsync());
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }

        private void ConfigureDatasetRepositoryMock(Mock<IDatasetRepository> datasetRepositoryMock)
        {
            datasetRepositoryMock.Setup(rep => rep.GetByNameAsync(_definedDatasets[0].Name.ToLower())).ReturnsAsync(() => new Dataset() { Id = 1} );
            datasetRepositoryMock.Setup(rep => rep.RemoveByIdAsync(1));
        }

        private void ConfigureDefinedDatasetRepositoryMock(Mock<IDefinedDatasetRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAllAsync()).ReturnsAsync(_definedDatasets.AsQueryable());
            repositoryMock.Setup(rep => rep.GetValuesAsync()).ReturnsAsync(_definedDatasetValues.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _definedDatasets[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);
            repositoryMock.Setup(rep => rep.GetValuesByDatasetIdAsync(1)).ReturnsAsync(_definedDatasetValues.Where(item => item.Dataset.Id == 1).AsQueryable());
            repositoryMock.Setup(rep => rep.GetValuesByDatasetIdAsync(3)).ReturnsAsync(() => null);
            repositoryMock.Setup(rep => rep.GetDatasetsByTypeIdAsync(1)).ReturnsAsync(() => new List<DefinedDataset> { _definedDatasets[0] });
            repositoryMock.Setup(rep => rep.GetDatasetsByTypeIdAsync(3)).ReturnsAsync(() => null);

            repositoryMock.Setup(rep => rep.AddAsync(null));
            repositoryMock.Setup(rep => rep.AddValuesAsync(null));

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).ReturnsAsync(() => false);
            repositoryMock.Setup(rep => rep.RemoveValueByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveValueByIdAsync(5)).ReturnsAsync(() => false);
        }

        [Fact]
        public async void GetAll_RightDefinedDatasetsCount()
        {
            var result = await _definedDatasetService.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetValues_RightDefinedDatasetValuesCount()
        {
            var result = await _definedDatasetService.GetValuesAsync();

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightDefinedDataset()
        {
            var result = await _definedDatasetService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _definedDatasetService.GetByIdAsync(3));
        }

        [Fact]
        public async void GetValuesByDatasetId_ExistingId_RightValues()
        {
            var result = await _definedDatasetService.GetValuesByDatasetIdAsync(1);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetValuesByDatasetId_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _definedDatasetService.GetValuesByDatasetIdAsync(3));
        }

        [Fact]
        public async void GetDatasetsByTypeId_ExistingId_RightValues()
        {
            var result = await _definedDatasetService.GetDatasetsByTypeIdAsync(1);

            Assert.Single(result);
        }

        [Fact]
        public async void GetDatasetsByTypeId_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _definedDatasetService.GetDatasetsByTypeIdAsync(3));
        }
        
        [Fact]
        public void AddValuesAsync_NonExistingElements_NoException()
        {
            var ex = Record.ExceptionAsync(() => _definedDatasetService.AddValuesAsync(null));

            Assert.Null(ex.Result);
        }

        [Fact]
        public void RemoveDatasetAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _definedDatasetService.RemoveDatasetAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveDatasetAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _definedDatasetService.RemoveDatasetAsync(3));
        }

        [Fact]
        public void RemoveValueByIdAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _definedDatasetService.RemoveValueByIdAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveValueByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _definedDatasetService.RemoveValueByIdAsync(5));
        }
    }
}
