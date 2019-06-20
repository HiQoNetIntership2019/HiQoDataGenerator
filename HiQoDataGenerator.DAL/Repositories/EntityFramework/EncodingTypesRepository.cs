using System.Linq;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;


namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class EncodingTypesRepository: IBaseRepository<EncodingType>
    {
        DataContext _context;

        public EncodingTypesRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<EncodingType> GetAll()
        {
            return _context.EncodingTypes.ToList();
        }

        public EncodingType GetById(int id)
        {
            return _context.EncodingTypes.Where(type => type.Id == id).ToList().First();
        }

        public EncodingType GetByName(string name)
        {
            return _context.EncodingTypes.Where(type => type.Name == name).ToList().First();
        }

        public void Add(EncodingType type)
        {
            _context.EncodingTypes.Add(type);
            _context.SaveChanges();
        }

        public void AddRange(IEnumerable<EncodingType> typesRange)
        {
            _context.EncodingTypes.AddRange(typesRange);
            _context.SaveChanges();
        }

        public bool RemoveById(int id)
        {
            var searchResult = _context.EncodingTypes.Where(type => type.Id == id).ToList();

            if (searchResult.Count != 0)
            {
                _context.EncodingTypes.Remove(searchResult.First());
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
