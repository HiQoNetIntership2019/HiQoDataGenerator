using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class ConfigurableObjectsServiceTest
    {
        private readonly Mock<IConfigurableObjectsRepository> _configurableObjectsRepositoryMock = new Mock<IConfigurableObjectsRepository>();
        private readonly Mock<IFieldTypeRepository> _fieldTypesRepositoryMock = new Mock<IFieldTypeRepository>();
        private readonly Mock<IConstraintsRepository> _constraintRepositoryMock = new Mock<IConstraintsRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();


        private readonly Mock<IMapperFactory> _mapperFactoryMock = new Mock<IMapperFactory>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

        
        private readonly IConfigurableObjectsService _configurableObjectsService;


        public ConfigurableObjectsServiceTest()
        {
            ConfigureUOWMock(_unitOfWorkMock);
            _mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(_mapperMock.Object);
            _configurableObjectsService = new ConfigurableObjectsService(_unitOfWorkMock.Object, 
                _mapperFactoryMock.Object, _configurableObjectsRepositoryMock.Object, _fieldTypesRepositoryMock.Object,
                _constraintRepositoryMock.Object);           
        }

        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {   
            uowMock.Setup(uow => uow.CommitAsync());
        }

        [Fact]
        public async Task AddAsync_IsAdded()
        {
            var listConfigurableObjects = new List<ConfigurableObjectModel>();
            var (coreModel, dalModel) = GetModels();

            _configurableObjectsRepositoryMock.Setup(repository => repository.AddAsync(dalModel))
                .Callback(() => listConfigurableObjects.Add(coreModel));

            await _configurableObjectsService.AddAsync(coreModel);

            Assert.Contains(coreModel, listConfigurableObjects);
        }

        [Fact]
        public async Task RemoveByIdAsync_IsRemove()
        {
            int idForRemove = 0;
            var listConfigurableObjects = CreateConfigurableObjects();
            var removedConfigurableObject = listConfigurableObjects.Find(item => item.Id == idForRemove);

            _configurableObjectsRepositoryMock.Setup(repository =>  repository.RemoveByIdAsync(idForRemove))
                .Callback(() => listConfigurableObjects.Remove(removedConfigurableObject));

            await _configurableObjectsService.RemoveById(idForRemove);

            Assert.DoesNotContain(removedConfigurableObject, listConfigurableObjects);

        }


        private (ConfigurableObjectModel coreModel, ConfigurableObject dalModel) GetModels()
        {
            var dateCreation = DateTime.Now.AddDays(-3);
            var dateChange = DateTime.Now.AddDays(-2);

            var coreModel = new ConfigurableObjectModel(12, "test", dateCreation, dateChange, null);
            var dalModel = new ConfigurableObject()
            {
                Id = 12,
                Name = "test",
                DateCreation = dateCreation,
                DateChange = dateChange,
                Fields = new List<Field>()
            };

            _mapperMock.Setup(mapper => mapper.Map<ConfigurableObjectModel>(dalModel)).Returns(coreModel);
            _mapperMock.Setup(mapper => mapper.Map<ConfigurableObject>(coreModel)).Returns(dalModel);

            return (coreModel, dalModel);
        }

        private List<ConfigurableObjectModel> CreateConfigurableObjects() =>
            new List<ConfigurableObjectModel>()
            {
                new ConfigurableObjectModel(0, "first", DateTime.Now, null, null),
                new ConfigurableObjectModel(1, "second", DateTime.Now.AddDays(-1), null, null),
                new ConfigurableObjectModel(2, "third", DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-1), null)
            };
        
    }
}
