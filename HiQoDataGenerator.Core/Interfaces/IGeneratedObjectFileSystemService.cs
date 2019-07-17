using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IGeneratedObjectFileSystemService
    {
        Task<GeneratedObjectModel> ReadFromFile(string fullPath);
        Task<string> CreateFile(GeneratedObjectModel generatedObject);
        Task DeleteFile(string fullPath);
    }
}