using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.UnitOfWork;
using System.Linq;

namespace HiQoDataGenerator.Core.Services
{
    public class FileMetadataService : IFileMetadataService
    {
        private readonly IFileMetadataRepository _fileMetadataRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public FileMetadataService(IUnitOfWork unit, IFileMetadataRepository fileMetadataRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _fileMetadataRepository = fileMetadataRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public async Task AddAsync(FileMetadataModel fileMetadataModel)
        {
            var metadata = _mapper.Map<FileMetadata>(fileMetadataModel);
            await _fileMetadataRepository.AddAsync(metadata);
            await _uow.CommitAsync();
        }

        public IEnumerable<FileMetadataModel> GetAll()
        {
            var metadata = _fileMetadataRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<FileMetadataModel>>(metadata);
        }

        public async Task<FileMetadataModel> GetByIdAsync(int id)
        {
            var metadata = await _fileMetadataRepository.GetByIdAsync(id);
            if (metadata == null)
            {
                throw new InvalidDataException($"Can't get File Metadata with id {id}!");
            }
            return _mapper.Map<FileMetadataModel>(metadata);
        }

        public async Task<IEnumerable<FileMetadataModel>> GetByStatusId(int id)
        {
            var metadata = await _fileMetadataRepository.GetByStatusId(id);
            if (metadata == null)
            {
                throw new InvalidDataException($"Can't get File Metadata with Status id {id} !");
            }
            return _mapper.Map<IEnumerable<FileMetadataModel>>(metadata);
        }

        public async Task<IEnumerable<FileMetadataModel>> GetByStatusName(string name)
        {
            var metadata = await _fileMetadataRepository.GetByStatusName(name.ToLower());
            if (metadata == null)
            {
                throw new InvalidDataException($"Can't get File Metadata with Status <{name}> !");
            }
            return _mapper.Map<IEnumerable<FileMetadataModel>>(metadata);
        }

        public async Task RemoveAsync(int fileMetadataId)
        {
            var result = await _fileMetadataRepository.RemoveByIdAsync(fileMetadataId);
            if (!result)
            {
                throw new InvalidDataException($"Can't delete File Metadata with id {fileMetadataId} !");
            }
            await _uow.CommitAsync();
        }

        public async Task UpdateAsync(FileMetadataModel fileMetadataModel)
        {
            var metadata = _mapper.Map<FileMetadata>(fileMetadataModel);
            await _fileMetadataRepository.UpdateAsync(metadata);
            await _uow.CommitAsync();
        }

        public async Task UpdateRangeAsync(IEnumerable<FileMetadataModel> fileMetadataModels)
        {
            var metadata = _mapper.Map<IEnumerable<FileMetadata>>(fileMetadataModels);
            await _fileMetadataRepository.UpdateRangeAsync(metadata);
            await _uow.CommitAsync();
        }
    }
}
