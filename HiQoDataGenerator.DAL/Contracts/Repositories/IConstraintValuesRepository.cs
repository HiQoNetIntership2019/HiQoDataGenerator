using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IConstraintValuesRepository : IBaseRepository<ConstraintValue>
    {
        Task<IEnumerable<ConstraintValue>> GetByTypeAsync(int id);
    }
}
