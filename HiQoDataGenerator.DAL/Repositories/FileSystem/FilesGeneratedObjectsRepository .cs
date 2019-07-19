using HiQoDataGenerator.DAL.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.FileSystem
{
    public class FilesGeneratedObjectsRepository : IFilesGeneratedObjectsRepository
    {
        private readonly string _rootDirectory;

        public FilesGeneratedObjectsRepository(IConfiguration configuration)
        {
            _rootDirectory = configuration["FileSystem:Root"];
        }

        public async Task CreateAndWriteInFile(string value, string directoryName, string fileName)
        {
            var directoryPath = Path.Combine(_rootDirectory, directoryName);

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var fullPath = Path.Combine(directoryPath, fileName);

            using (var writer = new StreamWriter(fullPath))
            {
                await writer.WriteAsync(value);
            }
        }

        public async Task DeleteFile(string directoryName, string fileName)
        {
            await Task.Run(() => File.Delete(Path.Combine(_rootDirectory, directoryName, fileName)));
        }

        public async Task DeleteFile(string fullPath)
        {
            await Task.Run(() => File.Delete(fullPath));
        }

        public async Task<string> ReadFromFile(string directoryName, string fileName)
        {
            var directoryPath = Path.Combine(_rootDirectory, directoryName);
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            using (var reader = new StreamReader(Path.Combine(directoryPath, fileName)))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<string> ReadFromFile(string fullPath)
        {
            using (var reader = new StreamReader(fullPath))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
