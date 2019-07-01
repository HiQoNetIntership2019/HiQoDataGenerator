using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class FeildsServiceTest
    {
        private readonly Mock<IMapperFactory> _mapperFactoryMock = new Mock<IMapperFactory>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IFieldRepository> _fieldRepositoryMock = new Mock<IFieldRepository>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>(); 

        private readonly IFieldsService _fieldsService;

        public FeildsServiceTest()
        {
            _mapperFactoryMock.Setup(value => value.GetMapper(typeof(CoreServices).Name)).Returns(_mapperMock.Object);

            _fieldsService = new FieldsService(_mapperFactoryMock.Object, _unitOfWorkMock.Object, _fieldRepositoryMock.Object);
        }

        [Fact]
        public async void AddAsync_IsAdded()
        {
            var storage = new List<FieldModel>();
            var (dalModel, coreModel) = GetModels();
            SetupMapping(dalModel, coreModel);
            _fieldRepositoryMock.Setup(repo => repo.AddAsync(dalModel)).Callback(() => storage.Add(coreModel));

            await _fieldsService.AddAsync(coreModel);

            Assert.Contains(coreModel, storage);
        }

        [Fact]
        public async void RemoveById_IsRemoved()
        {

            List<FieldModel> fieldModels = GetCollectionModels();
            FieldModel itemForRemoved = fieldModels[0];
            int idForRemoved = itemForRemoved.Id;
            _fieldRepositoryMock.Setup(repo => repo.RemoveByIdAsync(idForRemoved)).Callback(() =>
            {
                fieldModels.Remove(itemForRemoved);
            });

            await _fieldsService.RemoveByIdAsync(idForRemoved);

            Assert.DoesNotContain(itemForRemoved, fieldModels);
        }
       

        private (Field dalModel, FieldModel coreModel) GetModels()
        {
            int id = 12;
            string name = "test";
            bool isRequired = true;

            var dalModel = new Field() { Id = id, Name = name, IsRequired = isRequired, ConfigurableObject = null, FieldType = null, };
            var coreModel = new FieldModel(id, name, isRequired);

            return (dalModel, coreModel);
        }

        private List<FieldModel> GetCollectionModels()
        {
            return new List<FieldModel>()
            {
                new FieldModel(1, "first", true),
                new FieldModel(2, "second", false),
                new FieldModel(3, "third", true)
            };
        }

        private void SetupMapping<T1, T2>(T1 value1, T2 value2)
        {
            _mapperMock.Setup(m => m.Map<T1>(value2)).Returns(value1);
            _mapperMock.Setup(m => m.Map<T2>(value1)).Returns(value2);
        }
    }
}
