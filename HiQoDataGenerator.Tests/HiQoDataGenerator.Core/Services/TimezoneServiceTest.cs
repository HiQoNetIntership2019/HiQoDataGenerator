using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class TimezoneServiceTest
    {
        private readonly Mock<ITimezoneRepository> _timezoneRepositoryMock = new Mock<ITimezoneRepository>();
        private readonly Mock<IMapperFactory> _mapperFactoryMock = new Mock<IMapperFactory>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new Mock<IUnitOfWork>();

        private readonly ITimezonesService _timezoneService;

        private List<TimezoneModel> _timezoneModels = new List<TimezoneModel>();
        
        public TimezoneServiceTest()
        {
            ConfigureUOWMock(_unitOfWorkMock);
            _mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapperMock.Object);
            _timezoneService = new TimezoneService(_unitOfWorkMock.Object, _timezoneRepositoryMock.Object, _mapperFactoryMock.Object);
        }
        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {
            uowMock.Setup(uow => uow.CommitAsync());
        }

        [Fact]
        public async void AddAsync_IsAdded()
        {
            var (CoreModel, DalModel) = GetModels();
            _timezoneRepositoryMock.Setup(repository => repository.AddAsync(DalModel)).Callback(() =>
            {
                _timezoneModels.Add(CoreModel);
            });

            await _timezoneService.AddAsync(CoreModel);

            Assert.Contains(CoreModel, _timezoneModels);
        }

        [Fact]
        public async void RemoveByIdAsync_IsRemoved()
        {
            _timezoneModels = CreateModelSet();
            int idForRemoved = 3;
            var removedModel = _timezoneModels.Find(item => item.Id == idForRemoved);
            _timezoneRepositoryMock.Setup(repository => repository.RemoveByIdAsync(idForRemoved)).Callback(() =>
            {
                var item = _timezoneModels.Find(model => model.Id == idForRemoved);
                _timezoneModels.Remove(item);
            }).ReturnsAsync(true);

            await _timezoneService.RemoveByIdAsync(idForRemoved);

            Assert.DoesNotContain(removedModel, _timezoneModels);
        }

        private (TimezoneModel CoreModel, Timezone DalModel) GetModels()
        {
            var objectForAdded = new Timezone() { Value = "UTC+12" };
            var modelForAdded = new TimezoneModel(12, "UTC+12");
            _mapperMock.Setup(mapper => mapper.Map<Timezone>(modelForAdded)).Returns(objectForAdded);
            _mapperMock.Setup(mapper => mapper.Map<TimezoneModel>(objectForAdded)).Returns(modelForAdded);
            return (modelForAdded, objectForAdded);
        }


        private List<TimezoneModel> CreateModelSet() =>
            new List<TimezoneModel>()
            {
                new TimezoneModel(0, "UTC"),
                new TimezoneModel(1, "UTC+1"),
                new TimezoneModel(2, "UTC+2"),
                new TimezoneModel(3, "UTC-1")
            };
    }
}
