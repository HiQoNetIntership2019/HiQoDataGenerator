using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IConstraintsRepository : IGenericRepository<Constraint>
    {
        Task<Constraint> GetByNameAsync(string name);
        IEnumerable<Constraint> GetByFieldTypeId(int id);
    }
}
