using HiQoDataGenerator.DAL.Models.GeneratedObjects;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IGeneratedObjectsRepository
    {
        IEnumerable<CustomGeneratedObject> GetAll();
        Task<CustomGeneratedObject> GetByIdAsync(string id);
        Task AddAsync(CustomGeneratedObject item);
        Task AddRangeAsync(IEnumerable<CustomGeneratedObject> items);
        Task<bool> RemoveByIdAsync(string id);
    }
}
