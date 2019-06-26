using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.Core.Exceptions;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using System.Collections.Generic;
using HiQoDataGenerator.Core.UnitOfWork;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class RegexServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IRegexRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly List<Regex> _regexes; 
        private readonly IRegexService _regexService;

        public RegexServiceTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IRegexRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _regexes = GenerateRegexes();

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            ConfigureUOWMock(_unitOfWorkMock);
            _regexService = new RegexService(_unitOfWorkMock.Object, _repositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<Regex> GenerateRegexes()
        {
            return new List<Regex>() { new Regex() { Id = 1, Name="Email", Value= "^w+@[a-zA-Z_]+?[a-zA-Z]{2,3}$" },
                new Regex() { Id = 2, Name="URL", Value= "^[a-z]+([a-z0-9-]*[a-z0-9]+)?(([a-z]+([a-z0-9-]*[a-z0-9]+)?)+)*$" } };
        }

        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {
            uowMock.Setup(uow => uow.CommitAsync());
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }

        private void ConfigureRepositoryMock(Mock<IRegexRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAll()).Returns(_regexes.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _regexes[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);
            repositoryMock.Setup(rep => rep.GetAllNames()).Returns(_regexes.Select(n => n.Name).AsQueryable());


            repositoryMock.Setup(rep => rep.AddAsync(null));

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).ReturnsAsync(() => false);
        }

        [Fact]
        public void GetAll_RightRegexCount()
        {
            var result = _regexService.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightRegex()
        {
            var result = await _regexService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _regexService.GetByIdAsync(3));
        }

        [Fact]
        public void GetAll_RightNames()
        {
            var result = _regexService.GetAllNames();
            var expected = new List<string>(new string[] { "Email","URL"}).AsQueryable();
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddAsync_NonExistingElement_NoException()
        {
            var ex = Record.ExceptionAsync(() => _regexService.AddAsync(null));

            Assert.Null(ex.Result);
        }

        [Fact]
        public void RemoveByIdAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _regexService.RemoveByIdAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveByIdAsync_NonExistingId_ElementNotFoundException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _regexService.RemoveByIdAsync(3));
        }
    }
}
