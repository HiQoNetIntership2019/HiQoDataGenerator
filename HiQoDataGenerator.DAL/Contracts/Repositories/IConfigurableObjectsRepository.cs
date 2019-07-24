using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IConfigurableObjectsRepository : IGenericRepository<ConfigurableObject>
    {
        Task<ConfigurableObject> GetByNameAsync(string name);
        Task<IQueryable<ConfigurableObject>> GetByDateCreationAsync(Predicate<DateTime> datePredicate);
        Task<IQueryable<ConfigurableObject>> GetAllWithFieldsAsync();
    }
}
