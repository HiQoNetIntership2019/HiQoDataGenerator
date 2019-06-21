using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<bool> AddAsync(T item);
        Task<bool> AddRangeAsync(IEnumerable<T> items);
        Task<bool> RemoveByIdAsync(int id);
    }
}
