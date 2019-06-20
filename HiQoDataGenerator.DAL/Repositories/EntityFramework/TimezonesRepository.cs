using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class TimezonesRepository : IBaseRepository<Timezone>
    {
        private readonly DataContext _context;

        public TimezonesRepository(DataContext context) => _context = context;

        public void Add(Timezone item)
        {
            _context.Timezones.Add(item);
            _context.SaveChangesAsync();
        }

        public void AddRange(IEnumerable<Timezone> items)
        {
            _context.Timezones.AddRange(items);
            _context.SaveChangesAsync();
        }

        public IEnumerable<Timezone> GetAll() => _context.Timezones;

        public Timezone GetById(int id) => _context.Timezones.Find(id);

        public bool RemoveById(int id)
        {
            var valueForRemove = GetById(id);
            if (valueForRemove == null)
            {
                return false;
            }
            _context.Remove(valueForRemove);
            return true;
        }
    }
}
