using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
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

        public async Task<string> CreateFile(GeneratedObjectModel generatedObject)
        {
            string json = JsonConvert.SerializeObject(generatedObject);
            string fileName = $"{generatedObject.DateCreation:s}_{generatedObject.Name}.json"
                .Replace(":", "")
                .Replace("-", "");
            await _filesGeneratedObjectsRepository.CreateAndWriteInFileAsync(json, _directoryName, fileName);
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), fileName));
        }

        public async Task<GeneratedObjectModel> ReadFromFile(string fullPath)
        {
            var jsonObject = await _filesGeneratedObjectsRepository.ReadFromFileAsync(fullPath);
            return JsonConvert.DeserializeObject<GeneratedObjectModel>(jsonObject);
            
        }

        public async Task DeleteFile(string fullPath)
        {
            await _filesGeneratedObjectsRepository.DeleteFileAsync(fullPath);
        }

    }
}
