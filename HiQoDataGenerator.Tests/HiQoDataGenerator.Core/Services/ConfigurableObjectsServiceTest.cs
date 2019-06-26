using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class ConfigurableObjectsServiceTest
    {
        private readonly Mock<IConfigurableObjectsRepository> _configurableObjectsRepositoryMock = new Mock<IConfigurableObjectsRepository>();
        private readonly Mock<IMapperFactory> _mapperFactoryMock = new Mock<IMapperFactory>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        private readonly IConfigurableObjectsService _configurableObjectsService;


        public ConfigurableObjectsServiceTest()
        {
            _mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(_mapperMock.Object);
            _configurableObjectsService = new ConfigurableObjectsService(_mapperFactoryMock.Object, _configurableObjectsRepositoryMock.Object);
           
        }

        [Fact]
        public void AddAsync_IsAdded()
        {
            var listConfigurableObjects = new List<ConfigurableObjectModel>();
            var (coreModel, dalModel) = GetModels();

            _configurableObjectsRepositoryMock.Setup(repository => repository.AddAsync(dalModel))
                .Callback(() => listConfigurableObjects.Add(coreModel));

            _configurableObjectsService.AddAsync(coreModel);

            Assert.Contains(coreModel, listConfigurableObjects);
        }

        [Fact]
        public void RemoveByIdAsync_IsRemove()
        {
            int idForRemove = 0;
            var listConfigurableObjects = CreateConfigurableObjects();
            var removedConfigurableObject = listConfigurableObjects.Find(item => item.Id == idForRemove);

            _configurableObjectsRepositoryMock.Setup(repository =>  repository.RemoveByIdAsync(idForRemove))
                .Callback(() => listConfigurableObjects.Remove(removedConfigurableObject));

            _configurableObjectsService.RemoveById(idForRemove);

            Assert.DoesNotContain(removedConfigurableObject, listConfigurableObjects);

        }


        private (ConfigurableObjectModel coreModel, ConfigurableObject dalModel) GetModels()
        {
            var dateCreation = DateTime.Now.AddDays(-3);
            var dateChange = DateTime.Now.AddDays(-2);

            var coreModel = new ConfigurableObjectModel(12, "test", dateCreation, dateChange);
            var dalModel = new ConfigurableObject()
            {
                Id = 12,
                Name = "test",
                DateCreation = dateCreation,
                DateChange = dateChange
            };

            _mapperMock.Setup(mapper => mapper.Map<ConfigurableObjectModel>(dalModel)).Returns(coreModel);
            _mapperMock.Setup(mapper => mapper.Map<ConfigurableObject>(coreModel)).Returns(dalModel);

            return (coreModel, dalModel);
        }

        private List<ConfigurableObjectModel> CreateConfigurableObjects() =>
            new List<ConfigurableObjectModel>()
            {
                new ConfigurableObjectModel(0, "first", DateTime.Now, null),
                new ConfigurableObjectModel(1, "second", DateTime.Now.AddDays(-1), null),
                new ConfigurableObjectModel(2, "third", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1))
            };
        
    }
}
