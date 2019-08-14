using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IConstraintValuesService
    {
        Task<IEnumerable<ConstraintValueModel>> GetAllAsync();
        Task<ConstraintValueModel> GetByIdAsync(int id);
        Task<IEnumerable<ConstraintValueModel>> GetByTypeAsync(int typeId);
        Task AddAsync(ConstraintValueModel constraintModel);
        Task<bool> RemoveByIdAsync(int id);
    }
}
