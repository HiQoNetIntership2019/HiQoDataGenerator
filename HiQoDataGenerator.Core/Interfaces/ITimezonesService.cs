using HiQoDataGenerator.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface ITimezonesService
    {
        Task<IEnumerable<TimezoneModel>> GetAllAsync();
        Task AddAsync(TimezoneModel model);
        Task<bool> RemoveByIdAsync(int id);
        Task<TimezoneModel> GetByIdAsync(int id); 
    }
}
