using System.Linq;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class TypesRepository : IBaseRepository<FieldType>
    {
        DataContext _context;

        public TypesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<FieldType>> GetAll()
        {
            return _context.Types;
        }

        public async Task<FieldType> GetById(int id)
        {
            return await _context.Types.FindAsync(id);
        }
        
        public async void Add(FieldType type)
        {
            _context.Types.Add(type);
            await _context.SaveChangesAsync();
        }

        public async void AddRange(IEnumerable<FieldType> typesRange)
        {
            _context.Types.AddRange(typesRange);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveById(int id)
        {
            var searchResult = _context.Types.Where(type => type.Id == id).ToList();

            if (searchResult.Count != 0)
            {
                _context.Types.Remove(searchResult.First());
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
