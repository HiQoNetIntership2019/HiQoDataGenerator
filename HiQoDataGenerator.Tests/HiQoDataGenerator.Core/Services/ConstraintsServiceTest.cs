using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Moq;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class ConstraintServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IConstraintsRepository> _repositoryMock;
        private readonly List<Constraint> _constraints;
        private readonly IConstraintsService _constraintsService;

        public ConstraintServiceTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IConstraintsRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _constraints = GenerateConstraints();

            ConfigureMapperFactoryMock(_mapperFactoryMock);
            _constraintsService = new ConstraintsService(_repositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<Constraint> GenerateConstraints()
        {
            return new List<Constraint>()
            {
                new Constraint() { Id = 1, Name = "Max Length"},
                new Constraint() { Id = 2, Name = "Min Length"},
                new Constraint() { Id = 3, Name = "Min Value"},
                new Constraint() { Id = 4, Name = "Max Value"}
            };
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }

        private void ConfigureRepositoryMock_GetAll(Mock<IConstraintsRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAll()).Returns(_constraints.AsQueryable());
        }

        private void ConfigureRepositoryMock_GetByIdAsync(Mock<IConstraintsRepository> repositoryMock, int id)
        {
            repositoryMock.Setup(repository => repository.GetByIdAsync(id)).
                ReturnsAsync(() => _constraints.Find(constraint => constraint.Id == id));
        }

        private void ConfigureRepositoryMock_GetByNameAsync(Mock<IConstraintsRepository> repositoryMock, string name)
        {
            repositoryMock.Setup(repository => repository.GetByNameAsync(name)).
                ReturnsAsync(() => _constraints.Find(constraint => constraint.Name == name));
        }

        private void ConfigureRepositoryMock_RemoveByIdAsync(Mock<IConstraintsRepository> repositoryMock, int id)
        {
            repositoryMock.Setup(repository => repository.RemoveByIdAsync(id)).ReturnsAsync(() =>
            {
                var item = _constraints.Find(constraint => constraint.Id == id);
                return _constraints.Remove(item);
            });
        }

        [Fact]
        public void GetAll_CorrectConstraintsCount()
        {
            ConfigureRepositoryMock_GetAll(_repositoryMock);

            var result = _constraintsService.GetAll();

            Assert.Equal(_constraints.Count, result.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public async void GetByIdAsync_ExistingId_CorrectConstraint(int id)
        {
            ConfigureRepositoryMock_GetByIdAsync(_repositoryMock, id);
            var constraintName = _constraints.Find((element) => element.Id == id).Name;

            var result = await _constraintsService.GetByIdAsync(id);

            Assert.Equal(constraintName, result.Name);
        }

        [Theory]
        [InlineData("Max Value")]
        [InlineData("Max Length")]
        public async void GetByNameAsync_ExistingName_CorrectConstraint(string name)
        {
            ConfigureRepositoryMock_GetByNameAsync(_repositoryMock, name);
            var constraintId = _constraints.Find((element) => element.Name == name).Id;

            var result = await _constraintsService.GetByNameAsync(name);

            Assert.Equal(constraintId, result.Id);
        }

        [Theory]
        [InlineData(100)]
        public async Task GetByIdAsync_NonExistingId_ThrowsElementNotFoundException(int id)
        {
            ConfigureRepositoryMock_GetByIdAsync(_repositoryMock, id);

            await Assert.ThrowsAsync<InvalidDataException>(() => _constraintsService.GetByIdAsync(id));
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        public void RemoveByIdAsync_ExistingId_CanBeRemoved(int id)
        {
            ConfigureRepositoryMock_RemoveByIdAsync(_repositoryMock, id);

            _constraintsService.RemoveByIdAsync(id);
        }

        [Theory]
        [InlineData(100)]
        public async Task RemoveByIdAsync_NonExistingId_ElementNotFoundException(int id)
        {
            ConfigureRepositoryMock_RemoveByIdAsync(_repositoryMock, id);

            await Assert.ThrowsAsync<InvalidDataException>(() => _constraintsService.RemoveByIdAsync(id));
        }
    }
}
