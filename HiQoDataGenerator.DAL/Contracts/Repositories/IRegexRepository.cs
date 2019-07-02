using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IRegexRepository : IRepository<Regex>
    {
        IQueryable<string> GetAllNames();
    }
}
