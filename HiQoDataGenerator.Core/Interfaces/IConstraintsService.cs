using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IConstraintsService
    {
        Task<IEnumerable<ConstraintModel>> GetAllAsync();
        Task<ConstraintModel> GetByIdAsync(int id);
        Task<ConstraintModel> GetByNameAsync(string name);
        Task<IEnumerable<ConstraintModel>> GetByFieldTypeIdAsync(int id);
        Task AddAsync(ConstraintModel constraintModel);
        Task<bool> RemoveByIdAsync(int id);
        Task AddFieldTypesForConstraintAsync(ConstraintModel constraint, IEnumerable<FieldTypeModel> fieldTypes);
    }
}
