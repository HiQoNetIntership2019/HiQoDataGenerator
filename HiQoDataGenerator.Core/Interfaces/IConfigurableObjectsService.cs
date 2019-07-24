using HiQoDataGenerator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IConfigurableObjectsService
    {
        Task<IEnumerable<ConfigurableObjectModel>> GetAllAsync();
        Task<IEnumerable<ConfigurableObjectModel>> GetByDateCreatedAsync(Predicate<DateTime> datePredicate);
        Task AddAsync(ConfigurableObjectModel configurableObject);
        Task RemoveById(int id);
    }
}
