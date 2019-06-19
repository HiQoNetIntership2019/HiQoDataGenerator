using System.Collections.Generic;

namespace HiQoDataGenerator.DAL.Interfaces.Repositories
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
