using AutoMapper;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.UnitOfWork;
using System.Linq;

namespace HiQoDataGenerator.Core.Services
{
    public class FileStatusService : IFileStatusService
    {
        private readonly IFileStatusRepository _fileStatusRepository;
        private readonly IUnitOfWork _uow;
        private IMapper _mapper;

        public FileStatusService(IUnitOfWork unit, IFileStatusRepository fileStatusRepository, IMapperFactory mapperFactory)
        {
            _uow = unit;
            _fileStatusRepository = fileStatusRepository;
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
        }

        public IEnumerable<FileStatusModel> GetAll()
        {
            var statuses = _fileStatusRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<FileStatusModel>>(statuses);
        }

        public async Task<FileStatusModel> GetByIdAsync(int id)
        {
            var status = await _fileStatusRepository.GetByIdAsync(id);
            if (status == null)
            {
                throw new InvalidDataException($"Can't get File Status with id {id}!");
            }
            return _mapper.Map<FileStatusModel>(status);
        }

        public async Task<FileStatusModel> GetByName(string name)
        {
            var status = await _fileStatusRepository.GetByName(name.ToLower());
            if (status == null)
            {
                throw new InvalidDataException($"Can't get File Status with name <{name}>!");
            }
            return _mapper.Map<FileStatusModel>(status);
        }
    }
}
