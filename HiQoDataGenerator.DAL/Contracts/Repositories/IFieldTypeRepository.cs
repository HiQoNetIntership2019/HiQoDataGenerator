using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFieldTypeRepository : IGenericRepository<FieldType>
    {
        Task<bool> IsContainsAll(IEnumerable<FieldType> fieldTypes);
    }
}
