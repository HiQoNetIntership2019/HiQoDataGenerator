using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IGeneratedObjectFileSystemService
    {
        Task<IEnumerable<GeneratedObjectModel>> ReadFromFileAsync(string fullPath);
        Task<string> CreateFileAsync(IEnumerable<GeneratedObjectModel> generatedObject);
        Task DeleteFileAsync(string fullPath);
    }
}