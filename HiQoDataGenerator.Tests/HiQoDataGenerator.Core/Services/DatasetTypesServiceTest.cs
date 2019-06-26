using Moq;
using HiQoDataGenerator.Core.Interfaces;
using AutoMapper;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Entities;
using System.Collections.Generic;
using Xunit;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.Core.UnitOfWork;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class DatasetTypesServiceTest
    {
        private readonly Mock<IMapperFactory> _mapperFactoryMock = new Mock<IMapperFactory>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IDatasetTypesRepository> _datasetTypesRepositoryMock = new Mock<IDatasetTypesRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        private readonly IDatasetTypesService _datasetTypesService;

        public DatasetTypesServiceTest()
        {
            ConfigureUOWMock(_unitOfWorkMock);
            _mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(_mapperMock.Object);
            _datasetTypesService = new DatasetTypesService(_unitOfWorkMock.Object, _mapperFactoryMock.Object, _datasetTypesRepositoryMock.Object);
        }

        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {
            uowMock.Setup(uow => uow.CommitAsync());
        }

        [Fact]
        public void AddAsync_IsAdded()
        {
            var (coreModel, dalModel) = GetModels();
            var datasetTypes = CreateDatasetTypes();
            _datasetTypesRepositoryMock.Setup(repository => repository.AddAsync(dalModel)).Callback(() =>
            {
                datasetTypes.Add(coreModel);
            });

            _datasetTypesService.AddTypeAsync(coreModel);

            Assert.Contains(coreModel, datasetTypes);
        } 

        [Fact]
        public void RemoveByIdAsync_IsRemove()
        {
            int idForRemove = 0;
            var datasetTypes = CreateDatasetTypes();
            var datasetTypeForRemove = datasetTypes.Find(item => item.Id == idForRemove);

            _datasetTypesRepositoryMock.Setup(repository => repository.RemoveByIdAsync(idForRemove)).Callback(() =>
            {
                var item = datasetTypes.Find(type => type.Id == idForRemove);
                datasetTypes.Remove(item);
            }).ReturnsAsync(true);

            _datasetTypesService.RemoveById(idForRemove);

            Assert.DoesNotContain(datasetTypeForRemove, datasetTypes);
        }

        private (DatasetTypeModel coreModel, DatasetType dalModel) GetModels()
        {
            var coreModel = new DatasetTypeModel(12, "newtype");
            var dalModel = new DatasetType() { Id = 12, TypeName = "newtype" };

            _mapperMock.Setup(mapper => mapper.Map<DatasetTypeModel>(dalModel)).Returns(coreModel);
            _mapperMock.Setup(mapper => mapper.Map<DatasetType>(coreModel)).Returns(dalModel);

            return (coreModel, dalModel);
        }

        private List<DatasetTypeModel> CreateDatasetTypes() =>
            new List<DatasetTypeModel>()
            {
                new DatasetTypeModel(0, "defined"),
                new DatasetTypeModel(1, "custom")
            };
    }
}
