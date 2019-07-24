using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using Moq;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class ConstraintServiceTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IConstraintsRepository> _constraintsRepositoryMock;
        private readonly Mock<IFieldTypesConstraintsRepository> _fieldTypesConstraintsRepositoryMock;
        private readonly Mock<IFieldTypeRepository> _fieldTypeRepository;
        private readonly List<ConstraintModel> _constraintModels;
        private readonly IConstraintsService _constraintsService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public ConstraintServiceTest()
        {
            _mapperMock = new Mock<IMapper>();
            _constraintsRepositoryMock = new Mock<IConstraintsRepository>();
            _fieldTypesConstraintsRepositoryMock = new Mock<IFieldTypesConstraintsRepository>();
            _fieldTypeRepository = new Mock<IFieldTypeRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _constraintModels = GenerateConstraintModels();

            ConfigureUOWMock(_unitOfWorkMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            _constraintsService = new ConstraintsService(_unitOfWorkMock.Object, _constraintsRepositoryMock.Object, _mapperFactoryMock.Object,
                _fieldTypesConstraintsRepositoryMock.Object, _fieldTypeRepository.Object);
        }

        private List<ConstraintModel> GenerateConstraintModels()
        {
            return new List<ConstraintModel>()
            {
                new ConstraintModel(1, "Max Length", "Description 1"),
                new ConstraintModel(2, "Min Length", "Description 2"),
                new ConstraintModel(3, "Min Value", "Description 3"),
                new ConstraintModel(4, "Max Value", "Description 4")
            };
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapperMock.Object);
        }

        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {
            uowMock.Setup(uow => uow.CommitAsync());
        }

        private void ConfigureRepositoryMock_GetAll(Mock<IConstraintsRepository> repositoryMock)
        {
            var constraintList = _constraintModels.Select(item => new Constraint() { Name = item.Name, Description =  item.Description }).ToList();

            ConfigureModelMapperCollections(constraintList, _constraintModels);
            repositoryMock.Setup(repository => repository.GetAllAsync()).Returns(constraintList.AsQueryable());
        }

        private void ConfigureRepositoryMock_GetByIdAsync(Mock<IConstraintsRepository> repositoryMock, int id, Constraint constraint)
        {
            repositoryMock.Setup(repository => repository.GetByIdAsync(id)).
                ReturnsAsync(constraint);
        }

        private void ConfigureRepositoryMock_GetByNameAsync(Mock<IConstraintsRepository> repositoryMock, string name, Constraint constraint)
        {
            repositoryMock.Setup(repository => repository.GetByNameAsync(name)).
                ReturnsAsync(constraint);
        }

        private void ConfigureRepositoryMock_RemoveByIdAsync(Mock<IConstraintsRepository> repositoryMock, int id)
        {
            repositoryMock.Setup(repository => repository.RemoveByIdAsync(id)).ReturnsAsync(() =>
            {
                var item = _constraintModels.Find(constraint => constraint.Id == id);
                return _constraintModels.Remove(item);
            });
        }

        private void ConfigureRepositoryMock_AddAsync(Mock<IConstraintsRepository> repositoryMock, ConstraintModel coreModel, Constraint dalModel)
        {
            _constraintsRepositoryMock.Setup(repository => repository.AddAsync(dalModel)).Callback(() =>
            {
                _constraintModels.Add(coreModel);
            });
        }

        [Fact]
        public void GetAll_CorrectConstraintsCount()
        {
            ConfigureRepositoryMock_GetAll(_constraintsRepositoryMock);

            var result = _constraintsService.GetAllAsync();

            Assert.Equal(_constraintModels.Count, result.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(4)]
        public async void GetByIdAsync_ExistingId_CorrectConstraint(int id)
        {
            var constraintModel = _constraintModels.Find((element) => element.Id == id);
            var constraint = new Constraint() { Name = constraintModel.Name, Description = constraintModel.Description };
            ConfigureModelMapper(constraint, constraintModel);
            ConfigureRepositoryMock_GetByIdAsync(_constraintsRepositoryMock, id, constraint);

            var result = await _constraintsService.GetByIdAsync(id);

            Assert.Equal(constraintModel, result);
        }

        [Theory]
        [InlineData("Max Value")]
        [InlineData("Max Length")]
        public async void GetByNameAsync_ExistingName_CorrectConstraint(string name)
        {
            var constraintModel = _constraintModels.Find((element) => element.Name == name);
            var constraint = new Constraint() { Name = name, Description = constraintModel.Description };
            ConfigureModelMapper(constraint, constraintModel);
            ConfigureRepositoryMock_GetByNameAsync(_constraintsRepositoryMock, name, constraint);

            var result = await _constraintsService.GetByNameAsync(name);

            Assert.Equal(constraintModel, result);
        }

        [Theory]
        [InlineData(100)]
        public async Task GetByIdAsync_NonExistingId_ThrowsElementNotFoundException(int id)
        {
            ConfigureRepositoryMock_GetByIdAsync(_constraintsRepositoryMock, id, null);

            await Assert.ThrowsAsync<InvalidDataException>(() => _constraintsService.GetByIdAsync(id));
        }

        [Fact]
        public async Task AddAsync_NewConstraint_CanBeAdded()
        {
            var addedConstraint = new Constraint() { Name = "TimeZone", Description = "Description"};
            var addedConstraintModel = new ConstraintModel(5, "TimeZone", "Description");
            ConfigureModelMapper(addedConstraint, addedConstraintModel);
            ConfigureRepositoryMock_AddAsync(_constraintsRepositoryMock, addedConstraintModel, addedConstraint);

            await _constraintsService.AddAsync(addedConstraintModel);

            Assert.Contains(addedConstraintModel, _constraintModels);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        public void RemoveByIdAsync_ExistingId_CanBeRemoved(int id)
        {
            var constraintToRemove = _constraintModels.Find(constraint => constraint.Id == id);
            ConfigureRepositoryMock_RemoveByIdAsync(_constraintsRepositoryMock, id);

            _constraintsService.RemoveByIdAsync(id);

            Assert.DoesNotContain(constraintToRemove, _constraintModels);
        }

        [Theory]
        [InlineData(100)]
        public async Task RemoveByIdAsync_NonExistingId_ElementNotFoundException(int id)
        {
            ConfigureRepositoryMock_RemoveByIdAsync(_constraintsRepositoryMock, id);

            await Assert.ThrowsAsync<InvalidDataException>(() => _constraintsService.RemoveByIdAsync(id));
        }

        private void ConfigureModelMapper(Constraint objectForMapper, ConstraintModel modelForMapper)
        {
            _mapperMock.Setup(mapper => mapper.Map<Constraint>(modelForMapper)).Returns(objectForMapper);
            _mapperMock.Setup(mapper => mapper.Map<ConstraintModel>(objectForMapper)).Returns(modelForMapper);
        }

        private void ConfigureModelMapperCollections(IEnumerable<Constraint> objectsForMapper, IEnumerable<ConstraintModel> modelsForMapper)
        {
            _mapperMock.Setup(mapper => mapper.Map<IEnumerable<Constraint>, IEnumerable<ConstraintModel>>(objectsForMapper)).Returns(modelsForMapper);
        }
    }
}
