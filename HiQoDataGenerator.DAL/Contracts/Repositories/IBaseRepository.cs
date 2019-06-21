using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IBaseRepository<T>
    {
        IQueryable<T> GetAll();
        Task<T> GetById(int id);
        Task<bool> Add(T item);
        Task<bool> AddRange(IEnumerable<T> items);
        Task<bool> RemoveById(int id);
    }
}
