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
    public class FileMetadataTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMapperFactory> _mapperFactoryMock;
        private readonly Mock<IFileMetadataRepository> _repositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly List<FileMetadata> _metadata;
        private readonly List<FileStatus> _statuses;
        private readonly IFileMetadataService _fileMetadataService;

        public FileMetadataTest()
        {
            _mapper = CoreServices.GetMapper();
            _repositoryMock = new Mock<IFileMetadataRepository>();
            _mapperFactoryMock = new Mock<IMapperFactory>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
            _metadata = GenerateMetadata();
            _statuses = GenerateStatuses();

            ConfigureRepositoryMock(_repositoryMock);
            ConfigureMapperFactoryMock(_mapperFactoryMock);
            ConfigureUOWMock(_unitOfWorkMock);
            _fileMetadataService = new FileMetadataService(_unitOfWorkMock.Object, _repositoryMock.Object, _mapperFactoryMock.Object);
        }

        private List<FileMetadata> GenerateMetadata()
        {
            return new List<FileMetadata>() { new FileMetadata() { Id = 1, Path = "path1", StatusId = 1 }, new FileMetadata() { Id = 2, Path = "path2", StatusId = 2 } };
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

        private void ConfigureRepositoryMock(Mock<IFileMetadataRepository> repositoryMock)
        {
            repositoryMock.Setup(rep => rep.GetAllAsync()).Returns(_metadata.AsQueryable());
            repositoryMock.Setup(rep => rep.GetByIdAsync(1)).ReturnsAsync(() => _metadata[0]);
            repositoryMock.Setup(rep => rep.GetByIdAsync(3)).ReturnsAsync(() => null);
            repositoryMock.Setup(rep => rep.GetByStatusIdAsync(1)).ReturnsAsync(() => _metadata.Where(item => item.StatusId == 1));
            repositoryMock.Setup(rep => rep.GetByStatusIdAsync(3)).ReturnsAsync(() => null);

            repositoryMock.Setup(rep => rep.AddAsync(null));

            repositoryMock.Setup(rep => rep.RemoveByIdAsync(1)).ReturnsAsync(() => true);
            repositoryMock.Setup(rep => rep.RemoveByIdAsync(3)).ReturnsAsync(() => false);

            repositoryMock.Setup(rep => rep.UpdateAsync(null));
        }

        [Fact]
        public void GetAll_RightMetadataCount()
        {
            var result = _fileMetadataService.GetAll();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async void GetByIdAsync_ExistingId_RightMetadata()
        {
            var result = await _fileMetadataService.GetByIdAsync(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task GetByIdAsync_NonExistingId_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _fileMetadataService.GetByIdAsync(3));
        }

        [Fact]
        public async void GetByStatusIdAsync_ExistingId_RightMetadata()
        {
            var result = await _fileMetadataService.GetByStatusId(1);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetByStatusIdAsync_NonExistingId_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _fileMetadataService.GetByStatusId(3));
        }

        [Fact]
        public void AddAsync_NonExistingElement_NoException()
        {
            var ex = Record.ExceptionAsync(() => _fileMetadataService.AddAsync(null));

            Assert.Null(ex.Result);
        }

        [Fact]
        public void RemoveByIdAsync_ExistingId_NoException()
        {
            var ex = Record.ExceptionAsync(() => _fileMetadataService.RemoveAsync(1));

            Assert.Null(ex.Result);
        }

        [Fact]
        public async Task RemoveByIdAsync_NonExistingId_InvalidDataException()
        {
            await Assert.ThrowsAsync<InvalidDataException>(() => _fileMetadataService.RemoveAsync(3));
        }

        [Fact]
        public void UpdateAsync_NonExistingId_InvalidDataException()
        {
            var ex = Record.ExceptionAsync(() => _fileMetadataService.UpdateAsync(null));

            Assert.Null(ex.Result);
        }
    }
}
