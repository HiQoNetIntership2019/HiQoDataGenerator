using AutoMapper;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.GeneratedObjects;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class ServiceSavingGeneratedObjects : IServiceSavingGeneratedObjects
    {
        private readonly string _directoryForSave;

        private readonly IMapper _mapper;
        private readonly IGeneratedObjectsRepository _generatedObjectsRepository;
        private readonly IFilesGeneratedObjectsRepository _filesGeneratedObjectsRepository;

        public ServiceSavingGeneratedObjects(IMapperFactory factory, IConfiguration configuration,
            IGeneratedObjectsRepository generatedObjectsRepository, IFilesGeneratedObjectsRepository filesGeneratedObjectsRepository)
        {
            _directoryForSave = configuration["FileSystem:GeneratedObjectsDirectory"];
            _mapper = factory.GetMapper(typeof(CoreServices).Name);

            _filesGeneratedObjectsRepository = filesGeneratedObjectsRepository;
            _generatedObjectsRepository = generatedObjectsRepository;
        }


        public async Task MoveToStorage()
        {
            var jsonCollection = new List<string>();
            var pathsToJsons = new List<string>();

            foreach (var fileName in GetFileNamesForSave())
            {
                jsonCollection.Add(await _filesGeneratedObjectsRepository.ReadFromFile(_directoryForSave, fileName));
                await _filesGeneratedObjectsRepository.DeleteFile(_directoryForSave, fileName);
            }
           
            await _generatedObjectsRepository.AddRangeAsync(_mapper.Map<IEnumerable<CustomGeneratedObject>>(jsonCollection));
        }

        private IEnumerable<string> GetFileNamesForSave()
        {
            throw new NotImplementedException();
        }
    }
}
