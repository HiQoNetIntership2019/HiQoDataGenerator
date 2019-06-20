using System.Linq;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Threading.Tasks;


namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class EncodingTypesRepository: IBaseRepository<EncodingType>
    {
        DataContext _context;

        public EncodingTypesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<EncodingType>> GetAll()
        {
            return _context.EncodingTypes;
        }

        public async Task<EncodingType> GetById(int id)
        {
            return await _context.EncodingTypes.FindAsync(id);
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

        public async Task<bool> RemoveById(int id)
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
