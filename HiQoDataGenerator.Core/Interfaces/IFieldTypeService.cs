using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFieldTypeService
    {
        Task<IEnumerable<string>> GetSupportedTypesAsync();
        Task<IEnumerable<FieldTypeModel>> GetAllAsync();
        Task<FieldTypeModel> GetByIdAsync(int id);
        Task AddAsync(FieldTypeModel fieldTypeModel);
        Task RemoveByIdAsync(int id);
    }
}
