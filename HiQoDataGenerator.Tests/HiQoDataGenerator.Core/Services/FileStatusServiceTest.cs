using AutoMapper;
using HiQoDataGenerator.Core;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Services;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.Core.Exceptions;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using Xunit;
using System.Collections.Generic;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.Core.Services
{
    public class FileStatusServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IFileStatusRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly List<FileStatus> _statuses;
        private readonly IFileStatusService _fileStatusesService;

        public FileStatusServiceTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IFileStatusRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _statuses = GenerateStatuses();

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            ConfigureUOWMock(_unitOfWorkMock);
            _fileStatusesService = new FileStatusService(_unitOfWorkMock.Object, _repositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<FileStatus> GenerateStatuses()
        {
            return new List<FileStatus>() { new FileStatus() { Id = 1, Status = "NewFile" }, new FileStatus() { Id = 2, Status = "InProcessing" } };
        }

        private void ConfigureUOWMock(Mock<IUnitOfWork> uowMock)
        {
            uowMock.Setup(uow => uow.CommitAsync());
        }

        private void ConfigureMapperFactoryMock(Mock<IMapperFactory> mapperFactoryMock)
        {
            mapperFactoryMock.Setup(factory => factory.GetMapper(typeof(CoreServices).Name)).Returns(() => _mapper);
        }

        private void ConfigureRepositoryMock(Mock<IFileStatusRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAllAsync()).Returns(_statuses.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _statuses[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);
            repositoryMock.Setup(rep => rep.GetByNameAsync(_statuses[0].Status.ToLower())).ReturnsAsync(() => _statuses[0]);
            repositoryMock.Setup(rep => rep.GetByNameAsync("status")).ReturnsAsync(() => null);
        }

        [Fact]
        public void GetAll_RightStatusesCount()
        {
            var result = _fileStatusesService.GetAllAsync();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightStatus()
        {
            var result = await _fileStatusesService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _fileStatusesService.GetByIdAsync(3));
        }

        [Fact]
        public async void GetByNameAsync_ExistingName_RightStatus()
        {
            var result = await _fileStatusesService.GetByNameAsync(_statuses[0].Status);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByNameAsync_NonExistingName_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _fileStatusesService.GetByNameAsync("status"));
        }
    }
}
