using HiQoDataGenerator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IConfigurableObjectsService
    {
        IEnumerable<ConfigurableObjectModel> GetAll();
        IEnumerable<ConfigurableObjectModel> GetByDateCreated(Predicate<DateTime> datePredicate);
        Task AddAsync(ConfigurableObjectModel configurableObject);
        Task RemoveById(int id);
    }
}
