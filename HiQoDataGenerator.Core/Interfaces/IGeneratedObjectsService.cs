using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IGeneratedObjectsService
    {
        Task AddAsync(GeneratedObjectModel generatedObject);
        Task AddRangeAsync(IEnumerable<GeneratedObjectModel> generatedObjects);
        Task<IEnumerable<GeneratedObjectModel>> GetAllAsync();
        Task RemoveByIdAsync(string id);
    }
}