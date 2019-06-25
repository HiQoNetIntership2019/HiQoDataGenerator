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
        Task AddAsync(ConstraintModel constraintModel);
        Task RemoveByIdAsync(int id);
    }
}
