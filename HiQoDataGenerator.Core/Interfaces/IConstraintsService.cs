using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IConstraintsService
    {
        IEnumerable<ConstraintModel> GetAll();
        Task<ConstraintModel> GetByIdAsync(int id);
        Task<ConstraintModel> GetByNameAsync(string name);
        Task<IEnumerable<ConstraintModel>> GetByFieldTypeId(int id);
        Task AddAsync(ConstraintModel constraintModel);
        Task RemoveByIdAsync(int id);
        Task AddFieldTypesForConstraint(ConstraintModel constraint, IEnumerable<FieldTypeModel> fieldTypes);
    }
}
