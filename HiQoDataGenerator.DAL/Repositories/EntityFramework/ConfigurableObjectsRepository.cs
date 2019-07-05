using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class ConfigurableObjectsRepository : GenericRepository<ConfigurableObject>, IConfigurableObjectsRepository
    {
        public ConfigurableObjectsRepository(DataContext context) : base(context) { }

        public IQueryable<ConfigurableObject> GetByDateCreation(Predicate<DateTime> datePredicate) =>
            _models.Where(model => datePredicate(model.DateCreation));

        public async Task<ConfigurableObject> GetByName(string name) => await _models.FirstAsync(obj => obj.Name == name);

        public IQueryable<ConfigurableObject> GetAllWithFields()
        {
            return _models
                .Include(i => i.Fields)
                    .ThenInclude(i => i.FieldType)
                .Include(i => i.Fields)
                    .ThenInclude(i => i.ConstraintValues)
                        .ThenInclude(i => i.Constraint);
                    
        }
    }
}
