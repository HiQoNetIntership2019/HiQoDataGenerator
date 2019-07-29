﻿using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.IO;
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

        public async Task<string> CreateFileAsync(GeneratedObjectModel generatedObject)
        {
            string json = JsonConvert.SerializeObject(generatedObject);
            string fileName = $"{generatedObject.DateCreation:s}_{generatedObject.Name}.json"
                .Replace(":", "")
                .Replace("-", "");
            await _filesGeneratedObjectsRepository.CreateAndWriteInFileAsync(json, _directoryName, fileName);
            return Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), _rootDirectory, _directoryName, fileName));
        }

        public async Task<GeneratedObjectModel> ReadFromFileAsync(string fullPath)
        {
            var jsonObject = await _filesGeneratedObjectsRepository.ReadFromFileAsync(fullPath);
            return JsonConvert.DeserializeObject<GeneratedObjectModel>(jsonObject);

        }

        public async Task DeleteFileAsync(string fullPath)
        {
            await _filesGeneratedObjectsRepository.DeleteFileAsync(fullPath);
        }

    }
}
