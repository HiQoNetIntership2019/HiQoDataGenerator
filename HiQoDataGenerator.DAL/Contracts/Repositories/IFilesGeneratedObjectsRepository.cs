using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFilesGeneratedObjectsRepository
    {
        Task CreateAndWriteInFileAsync(string value, string directoryName, string fileName);
        Task DeleteFileAsync(string directoryName, string fileName);
        Task DeleteFileAsync(string fullPath);
        Task<string> ReadFromFileAsync(string directoryName, string fileName);
        Task<string> ReadFromFileAsync(string fullPath);
    }
}
