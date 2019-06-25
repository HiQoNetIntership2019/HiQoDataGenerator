using HiQoDataGenerator.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface ITimezonesService
    {
        IEnumerable<TimezoneModel> GetAll();
        Task AddAsync(TimezoneModel model);
        Task RemoveByIdAsync(int id);
        Task<TimezoneModel> GetByIdAsync(int id); 
    }
}
