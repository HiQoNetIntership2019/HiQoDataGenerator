﻿using AutoMapper;
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

        public async Task<IEnumerable<FileStatusModel>> GetAllAsync()
        {
            var statuses = await _fileStatusRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FileStatusModel>>(statuses.ToList());
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

        public async Task<FileStatusModel> GetByNameAsync(string name)
        {
            var status = await _fileStatusRepository.GetByNameAsync(name.ToLower());
            if (status == null)
            {
                throw new InvalidDataException($"Can't get File Status with name <{name}>!");
            }
            return _mapper.Map<FileStatusModel>(status);
        }
    }
}
