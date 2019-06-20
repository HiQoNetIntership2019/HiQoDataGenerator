using System.Linq;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class RegexRepository: IBaseRepository<Regex>
    {
        DataContext _context;
        public RegexRepository(DataContext context)
        {
            this._context = context;
        }
        public IEnumerable<Regex> GetAll()
        {
            return this._context.Regexes.ToList();
        }
        public Regex GetById(int id)
        {
            return this._context.Regexes.Where(regex => regex.Id == id).ToList().First();
        }
        public void Add(Regex item)
        {
            this._context.Regexes.Add(item);
            this._context.SaveChanges();
        }

        
        public void AddRange(IEnumerable<Regex> items)
        {
            this._context.Regexes.AddRange(items);
            this._context.SaveChanges();
        }
        public bool RemoveById(int id)
        {
            Regex item = _context.Regexes.Where(regex => regex.Id == id).First();
            if (item != null)
            {
                this._context.Regexes.Remove(item);
                this._context.SaveChanges();
                return true;
            }
            else
                return false;
        }
    }
}
