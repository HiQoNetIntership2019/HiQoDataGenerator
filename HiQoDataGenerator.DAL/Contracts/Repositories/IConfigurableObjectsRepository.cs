using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IConfigurableObjectsRepository : IGenericRepository<ConfigurableObject>
    {
        Task<ConfigurableObject> GetByName(string name);
        IEnumerable<ConfigurableObject> GetByDateCreation(Predicate<DateTime> datePredicate);
    }
}
