using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class ConstraintsRepository: BaseRepository<Constraint>
    {
        public ConstraintsRepository(DataContext context) : base(context) { }
        /* DataContext _context;

         public ConstraintsRepository(DataContext context)
         {
             _context = context;
         }

         public IEnumerable<Constraint> GetAll()
         {
             return _context.Constraints.ToList();
         }

         public Constraint GetById(int id)
         {
             return _context.Constraints.Find(id);
         }

         public Constraint GetByName(string name)
         {
             return _context.Constraints.Where(constraint => constraint.Name == name).ToList().First();
         }

         public void Add(Constraint constraint)
         {
             _context.Constraints.Add(constraint);
             _context.SaveChanges();
         }

         public void AddRange(IEnumerable<Constraint> constraintsRange)
         {
             _context.Constraints.AddRange(constraintsRange);
             _context.SaveChanges();
         }

         public bool RemoveById(int id)
         {
             var searchResult = _context.Constraints.Find(id);

             if (searchResult != null)
             {
                 _context.Constraints.Remove(searchResult);
                 _context.SaveChanges();
                 return true;
             }
             else
             {
                 return false;
             }
         }*/
    }
}
