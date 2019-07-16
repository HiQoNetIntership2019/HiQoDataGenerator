using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class GeneratedObjectFileSystemService : IGeneratedObjectFileSystemService
    {
        private readonly IFilesGeneratedObjectsRepository _filesGeneratedObjectsRepository;

        private readonly string _directoryName;

        public GeneratedObjectFileSystemService(IConfiguration configuration,
            IFilesGeneratedObjectsRepository filesGeneratedObjectsRepository)
        {
            _filesGeneratedObjectsRepository = filesGeneratedObjectsRepository;
            _directoryName = configuration["FileSystem:GeneratedObjectsDirectory"];
        }

        public async Task CreateFile(GeneratedObjectModel generatedObject)
        {
            string json = JsonConvert.SerializeObject(generatedObject);
            string fileName = $"{generatedObject.DateCreation}:{generatedObject.Name}";
            await _filesGeneratedObjectsRepository.CreateAndWriteInFile(json, _directoryName, fileName);
        }

        public async Task<GeneratedObjectModel> ReadFromFile(string fullPath)
        {
            var jsonObjects = await _filesGeneratedObjectsRepository.ReadFromFile(fullPath);
            return JsonConvert.DeserializeObject<GeneratedObjectModel>(jsonObjects);
            
        }

        public async Task DeleteFile(string fullPath)
        {
            await _filesGeneratedObjectsRepository.DeleteFile(fullPath);
        }

    }
}
