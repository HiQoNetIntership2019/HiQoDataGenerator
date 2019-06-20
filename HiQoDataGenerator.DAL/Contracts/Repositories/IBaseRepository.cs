﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        void Add(T item);
        void AddRange(IEnumerable<T> items);
        Task<bool> RemoveById(int id);
    }
}
