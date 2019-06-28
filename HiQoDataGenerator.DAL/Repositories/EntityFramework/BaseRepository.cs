using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected DbSet<T> _models;

        public BaseRepository(DataContext dataContext)
        {           
            _models = dataContext.Set<T>();
        }


        public async Task AddAsync(T item)
        {
            await _models.AddAsync(item);
        }

        public async Task AddRangeAsync(IEnumerable<T> items)
        {
            await _models.AddRangeAsync(items);
        }

        public IQueryable<T> GetAll() => _models;

        public async Task<T> GetByIdAsync(int id) => await _models.FindAsync(id);

        public async Task<bool> RemoveByIdAsync(int id)
        {
            var value = await _models.FindAsync(id);
            if (value == null)
            {
                return false;
            }
            _models.Remove(value);
            return true;
        }

        public void Update(T item) => _models.Update(item);

        public void UpdateRange(IEnumerable<T> items) => _models.UpdateRange(items);
    }
}
