using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class TimezonesRepository : IBaseRepository<Timezone>
    {
        private readonly DataContext _context;

        public TimezonesRepository(DataContext context) => _context = context;

        public void Add(Timezone item) => _context

        public void AddRange(IEnumerable<Timezone> items)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Timezone> GetAll()
        {
            throw new NotImplementedException();
        }

        public Timezone GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool RemoveById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
