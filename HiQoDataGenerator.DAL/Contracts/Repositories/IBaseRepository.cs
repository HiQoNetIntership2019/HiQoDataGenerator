using System.Collections.Generic;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void AddRange(IEnumerable<T> items);
        bool RemoveById(int id);
    }
}
