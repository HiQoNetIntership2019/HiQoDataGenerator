using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IGeneratedObjectFileSystemService
    {
        Task<GeneratedObjectModel> ReadFromFileAsync(string fullPath);
        Task<string> CreateFileAsync(GeneratedObjectModel generatedObject);
        Task DeleteFileAsync(string fullPath);
    }
}