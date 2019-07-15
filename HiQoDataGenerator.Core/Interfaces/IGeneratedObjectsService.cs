using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IGeneratedObjectsService
    {
        Task Add(GeneratedObjectModel generatedObject);
        Task AddRange(IEnumerable<GeneratedObjectModel> generatedObjects);
        IEnumerable<GeneratedObjectModel> GetAll();
        Task RemoveById(string id);
    }
}