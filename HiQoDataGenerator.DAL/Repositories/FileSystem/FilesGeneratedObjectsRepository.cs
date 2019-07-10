using HiQoDataGenerator.DAL.Contracts.Repositories;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace HiQoDataGenerator.DAL.Repositories.FileSystem
{
    public class FilesGeneratedObjectsRepository : IFilesGeneratedObjectsRepository
    {
        private readonly string _rootDirectory;
        
        public FilesGeneratedObjectsRepository(IConfiguration configuration)
        {
            _rootDirectory = configuration["FileSystem:root"];
        }

        public async Task CreateAndWriteInFile(string value, string path)
        {
            var fullPath = Path.Combine(_rootDirectory, path);
            File.Create(fullPath);

            using (var writer = new StreamWriter(fullPath))
            {
                await writer.WriteAsync(value);
            }
        }

        public async Task DeleteFile(string path)
        {
            await Task.Run(() => File.Delete(Path.Combine(_rootDirectory, path)));
        }

        public async Task<string> ReadFromFile(string path)
        {
            using (var reader = new StreamReader(Path.Combine(_rootDirectory, path)))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}
