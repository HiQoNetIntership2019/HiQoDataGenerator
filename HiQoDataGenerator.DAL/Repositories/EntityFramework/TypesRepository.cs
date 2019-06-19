using System.Linq;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Interfaces.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class TypesRepository : IBaseRepository<FieldType>
    {
        DataContext _context;

        public TypesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<FieldType> GetAll()
        {
            return _context.Types.ToList();
        }

        public FieldType GetById(int id)
        {
            return _context.Types.Where(type => type.Id == id).ToList().First();
        }

        public FieldType GetByName(string name)
        {
            return _context.Types.Where(type => type.Name == name).ToList().First();
        }

        public void Add(FieldType type)
        {
            _context.Types.Add(type);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<FieldType> typesRange)
        {
            _context.Types.AddRange(typesRange);
            _context.SaveChanges();
        }

        public bool RemoveById(int id)
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
