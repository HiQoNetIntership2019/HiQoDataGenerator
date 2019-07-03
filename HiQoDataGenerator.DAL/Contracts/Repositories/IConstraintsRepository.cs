using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IConstraintsRepository : IGenericRepository<Constraint>
    {
        Task<Constraint> GetByNameAsync(string name);
        IQueryable<Constraint> GetByFieldTypeId(int id);

        IQueryable<Constraint> GetAllWithFieldTypes();
    }
}
