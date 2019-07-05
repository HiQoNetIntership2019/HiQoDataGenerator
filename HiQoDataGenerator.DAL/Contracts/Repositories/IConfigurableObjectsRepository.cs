using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IConfigurableObjectsRepository : IGenericRepository<ConfigurableObject>
    {
        Task<ConfigurableObject> GetByName(string name);
        IQueryable<ConfigurableObject> GetByDateCreation(Predicate<DateTime> datePredicate);
        IQueryable<ConfigurableObject> GetAllWithFields();
    }
}
