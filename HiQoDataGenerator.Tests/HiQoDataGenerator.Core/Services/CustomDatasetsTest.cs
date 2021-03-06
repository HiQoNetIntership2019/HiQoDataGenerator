﻿using AutoMapper;
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
    public class CustomDatasetsTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<ICustomDatasetRepository> _repositoryMock;
        private readonly Mock<IDatasetRepository> _datasetRepositoryMock;
        private readonly Mock<IFieldTypeRepository> _typesRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly List<CustomDataset> _customDatasets;
        private readonly List<CustomDatasetValue> _customDatasetValues;
        private readonly ICustomDatasetService _customDatasetService;

        public CustomDatasetsTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<ICustomDatasetRepository>();
            _datasetRepositoryMock = new Mock<IDatasetRepository>();
            _typesRepositoryMock = new Mock<IFieldTypeRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _customDatasets = GenerateCustomDatasets();
            _customDatasetValues = GenerateCustomDatasetValues(_customDatasets);

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureDatasetRepositoryMock(_datasetRepositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            ConfigureUOWMock(_unitOfWorkMock);
            _customDatasetService = new CustomDatasetService(_unitOfWorkMock.Object, _repositoryMock.Object, 
                _datasetRepositoryMock.Object, _typesRepositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<CustomDataset> GenerateCustomDatasets()
        {
            return new List<CustomDataset>() { new CustomDataset() { Id = 1, Name = "Cities" }, new CustomDataset() { Id = 2, Name = "Books" } };
        }

        private List<CustomDatasetValue> GenerateCustomDatasetValues(List<CustomDataset> customDatasets)
        {
            return new List<CustomDatasetValue>() { new CustomDatasetValue() { Id = 1, Value = "City1", Dataset = customDatasets[0] },
                                                    new CustomDatasetValue() { Id = 2, Value = "City2", Dataset = customDatasets[0] },
                                                    new CustomDatasetValue() { Id = 3, Value = "Book1", Dataset = customDatasets[1] },
                                                    new CustomDatasetValue() { Id = 4, Value = "Book2", Dataset = customDatasets[1] }
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
            datasetRepositoryMock.Setup(rep => rep.GetByNameAsync(_customDatasets[0].Name.ToLower())).ReturnsAsync(() => new Dataset() { Id = 1 });
            datasetRepositoryMock.Setup(rep => rep.RemoveByIdAsync(1));
        }

        private void ConfigureRepositoryMock(Mock<ICustomDatasetRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAllAsync()).ReturnsAsync(_customDatasets.AsQueryable());
            repositoryMock.Setup(rep => rep.GetValuesAsync()).ReturnsAsync(_customDatasetValues.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _customDatasets[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);
            repositoryMock.Setup(rep => rep.GetValuesByDatasetIdAsync(1)).ReturnsAsync(_customDatasetValues.Where(item => item.Dataset.Id == 1).AsQueryable());
            repositoryMock.Setup(rep => rep.GetValuesByDatasetIdAsync(3)).ReturnsAsync(() => null);

            repositoryMock.Setup(rep => rep.AddAsync(null));
            repositoryMock.Setup(rep => rep.AddValuesAsync(null));

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).ReturnsAsync(() => false);
            repositoryMock.Setup(rep => rep.RemoveValueByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveValueByIdAsync(5)).ReturnsAsync(() => false);
        }

        [Fact]
        public async void GetAll_RightCustomDatasetsCount()
        {
            var result = await _customDatasetService.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetValues_RightCustomDatasetValuesCount()
        {
            var result = await _customDatasetService.GetValuesAsync();

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightCustomDataset()
        {
            var result = await _customDatasetService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _customDatasetService.GetByIdAsync(3));
        }

        [Fact]
        public async void GetValuesByDatasetId_ExistingId_RightValues()
        {
            var result = await _customDatasetService.GetValuesByDatasetIdAsync(1);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetValuesByDatasetId_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _customDatasetService.GetValuesByDatasetIdAsync(3));
        }
        
        [Fact]
        public void AddValuesAsync_NonExistingElements_NoException()
        {
            var ex = Record.ExceptionAsync(() => _customDatasetService.AddValuesAsync(null));

            Assert.Null(ex.Result);
        }

        [Fact]
        public void RemoveDatasetAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _customDatasetService.RemoveDatasetAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveDatasetAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _customDatasetService.RemoveDatasetAsync(3));
        }

        [Fact]
        public void RemoveValueByIdAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _customDatasetService.RemoveValueByIdAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveValueByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _customDatasetService.RemoveValueByIdAsync(5));
        }
    }
}

