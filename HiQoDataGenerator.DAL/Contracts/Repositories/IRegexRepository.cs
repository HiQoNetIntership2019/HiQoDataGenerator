using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IRegexRepository : IBaseRepository<Regex>
    {
        IQueryable<string> GetAllNames();
    }
}
