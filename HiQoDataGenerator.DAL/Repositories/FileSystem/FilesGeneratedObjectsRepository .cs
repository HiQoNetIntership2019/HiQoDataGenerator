using HiQoDataGenerator.DAL.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.MongoDirver
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
            var fullPath = Path.Combine(_rootDirectory, directoryName, fileName);
            File.Create(fullPath);

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
            using (var reader = new StreamReader(Path.Combine(_rootDirectory, directoryName, fileName)))
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
