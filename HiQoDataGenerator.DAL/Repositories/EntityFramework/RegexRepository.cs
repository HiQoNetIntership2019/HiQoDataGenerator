using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class RegexRepository : BaseRepository<Regex>, IRegexRepository
    { 
        public RegexRepository(DataContext context) : base(context) { }
        public IQueryable<string> GetAllNames() => base.GetAll().Select(r => r.Name).Distinct();
    }
}
