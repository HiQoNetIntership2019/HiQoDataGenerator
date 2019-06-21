using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IConstraintsRepository : IBaseRepository<Constraint>
    {
        Task<Constraint> GetByName(string name);
    }
}
