using System;
using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Services
{
    public class GeneratedObjectFileSystemService : IGeneratedObjectFileSystemService
    {
        private readonly IFilesGeneratedObjectsRepository _filesGeneratedObjectsRepository;

        private readonly string _directoryName;
        private readonly string _rootDirectory;


        public GeneratedObjectFileSystemService(IConfiguration configuration,
            IFilesGeneratedObjectsRepository filesGeneratedObjectsRepository)
        {
            _filesGeneratedObjectsRepository = filesGeneratedObjectsRepository;
            _rootDirectory = configuration["FileSystem:Root"];
            _directoryName = configuration["FileSystem:GeneratedObjectsDirectory"];
        }

        public async Task<string> CreateFileAsync(IEnumerable<GeneratedObjectModel> generatedObject)
        {
            string json = JsonConvert.SerializeObject(generatedObject);
            string fileName = $"{generatedObject.FirstOrDefault()?.DateCreation:s}_{Guid.NewGuid()}_{generatedObject.FirstOrDefault()?.Name}.json"
                .Replace(":", "")
                .Replace("-", "");
            await _filesGeneratedObjectsRepository.CreateAndWriteInFileAsync(json, _directoryName, fileName);
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), _rootDirectory, _directoryName, fileName));
        }

        public async Task<IEnumerable<GeneratedObjectModel>> ReadFromFileAsync(string fullPath)
        {
            var jsonObject = await _filesGeneratedObjectsRepository.ReadFromFileAsync(fullPath);
            return JsonConvert.DeserializeObject<IEnumerable<GeneratedObjectModel>>(jsonObject);

        }

        public async Task DeleteFileAsync(string fullPath)
        {
            await _filesGeneratedObjectsRepository.DeleteFileAsync(fullPath);
        }

    }
}
