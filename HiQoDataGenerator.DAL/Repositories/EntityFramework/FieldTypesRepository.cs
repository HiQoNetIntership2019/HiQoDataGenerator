using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FieldTypesRepository : IFieldTypeRepository
    {
        protected DataContext _context;
        protected DbSet<FieldType> _models;

        public FieldTypesRepository(DataContext context)
        {
            _context = context;
            _models = context.Set<FieldType>();
        }

        public async Task<bool> Add(FieldType item)
        {
            _models.Add(item);
            var result = await _context.SaveChangesAsync();
            return result != 0;;
        }

        public async Task<bool> AddRange(IEnumerable<FieldType> items)
        {
            _models.AddRange(items);
            var result = await _context.SaveChangesAsync();
            return result != 0;
        }

        public IQueryable<FieldType> GetAll() => _models;

        public async Task<FieldType> GetById(int id) => await _models.FindAsync(id);

        public async Task<bool> RemoveById(int id)
        {
            var value = _models.Find(id);
            if (value == null)
            {
                return false;
            }
            _models.Remove(value);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
