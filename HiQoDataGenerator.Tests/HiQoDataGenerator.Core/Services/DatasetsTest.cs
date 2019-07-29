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
using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class DatasetsTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IDefinedDatasetRepository> _definedDatasetRepositoryMock;
        private readonly Mock<ICustomDatasetRepository> _customDatasetRepositoryMock;
        private readonly Mock<IDatasetRepository> _datasetRepositoryMock;
        private readonly Mock<IFieldTypeRepository> _fieldTypeRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly List<Dataset> _datasets;
        private readonly List<DefinedDatasetValue> _definedDatasetValues;
        private readonly List<CustomDatasetValue> _customDatasetValues;
        private readonly IDatasetService _datasetService;

        public DatasetsTest()
        {
            _mapper = CoreServices.GetMapper();
            _definedDatasetRepositoryMock = new Mock<IDefinedDatasetRepository>();
            _customDatasetRepositoryMock = new Mock<ICustomDatasetRepository>();
            _datasetRepositoryMock = new Mock<IDatasetRepository>();
            _fieldTypeRepositoryMock = new Mock<IFieldTypeRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _datasets = GenerateDatasets();
            _definedDatasetValues = GenerateDefinedDatasetValues();
            _customDatasetValues = GenerateCustomDatasetValues();

            ConfigureDefinedDatasetRepositoryMock(_definedDatasetRepositoryMock);
            ConfigureDatasetRepositoryMock(_datasetRepositoryMock);
            ConfigureCustomDatasetRepositoryMock(_customDatasetRepositoryMock);
            ConfigureFieldTypeRepositoryMock(_fieldTypeRepositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            ConfigureUOWMock(_unitOfWorkMock);
            _datasetService = new DatasetService(_unitOfWorkMock.Object, _definedDatasetRepositoryMock.Object, 
                _customDatasetRepositoryMock.Object, _datasetRepositoryMock.Object, _fieldTypeRepositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<Dataset> GenerateDatasets()
        {
            return new List<Dataset>() {
                new Dataset() { Id = 1, Name = "Cities", TypeId = 1, IsDefined = true },
                new Dataset() { Id = 1, Name = "Dates", TypeId = 2, IsDefined = false }
            };
        }

        private List<DefinedDatasetValue> GenerateDefinedDatasetValues()
        {
            return new List<DefinedDatasetValue>() { new DefinedDatasetValue() { Id = 1, Value = "City1", DatasetId = 1 },
                                                     new DefinedDatasetValue() { Id = 2, Value = "City2", DatasetId = 1 },
                                                     new DefinedDatasetValue() { Id = 3, Value = "City3", DatasetId = 1 }
            };
        }

        private List<CustomDatasetValue> GenerateCustomDatasetValues()
        {
            return new List<CustomDatasetValue>() { new CustomDatasetValue() { Id = 1, Value = "Date1", DatasetId = 2 },
                                                    new CustomDatasetValue() { Id = 2, Value = "Date2", DatasetId = 2 },
                                                    new CustomDatasetValue() { Id = 3, Value = "Date3", DatasetId = 2 }
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
            _datasetRepositoryMock.Setup(rep => rep.GetAllAsync()).ReturnsAsync(_datasets.AsQueryable());
            _datasetRepositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _datasets[0]);
            _datasetRepositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);
            _datasetRepositoryMock.Setup(rep => rep.GetDatasetsByTypeIdAsync(1)).ReturnsAsync(() => new List<Dataset>() { _datasets[0] });
            _datasetRepositoryMock.Setup(rep => rep.GetDatasetsByTypeIdAsync(3)).ReturnsAsync(() => null);
        }

        private void ConfigureDefinedDatasetRepositoryMock(Mock<IDefinedDatasetRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetByNameAsync(_datasets[0].Name.ToLower())).ReturnsAsync(new DefinedDataset() { Id = 1 });
            repositoryMock.Setup(rep => rep.GetValuesByDatasetIdAsync(1)).ReturnsAsync(_definedDatasetValues.AsQueryable());
        }

        private void ConfigureCustomDatasetRepositoryMock(Mock<ICustomDatasetRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetDatasetByNameAsync(_datasets[0].Name.ToLower())).ReturnsAsync(new CustomDataset() { Id = 1 });
            repositoryMock.Setup(rep => rep.GetValuesByDatasetIdAsync(1)).ReturnsAsync(_customDatasetValues.AsQueryable());
        }

        private void ConfigureFieldTypeRepositoryMock(Mock<IFieldTypeRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => new FieldType() { Id = 1 , Name = "String"});
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => new FieldType() { Id = 2, Name = "Int" });
        }

        [Fact]
        public async void GetAll_RightDatasetsCount()
        {
            var result = await _datasetService.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightDefinedDataset()
        {
            var result = await _datasetService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _datasetService.GetByIdAsync(3));
        }

        [Fact]
        public async void GetValuesByDatasetId_ExistingId_RightValues()
        {
            var result = await _datasetService.GetValuesByDatasetIdAsync(1);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public async void GetValuesByDatasetId_NonExistingId_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _datasetService.GetValuesByDatasetIdAsync(3));
        }

        [Fact]
        public async void GetDatasetsByTypeId_ExistingId_RightValues()
        {
            var result = await _datasetService.GetDatasetsByTypeIdAsync(1);

            Assert.Single(result);
        }

        [Fact]
        public async void GetDatasetsByTypeId_NonExistingId_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _datasetService.GetDatasetsByTypeIdAsync(3));
        }

        [Fact]
        public async void ToDefinedDataset_DefinedDataset_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _datasetService.ToDefinedDatasetAsync(1));
        }
    }
}
