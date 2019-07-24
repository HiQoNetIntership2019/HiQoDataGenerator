using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using System.Threading.Tasks;
using System.Linq;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class RegexRepository : GenericRepository<Regex>, IRegexRepository
    { 
        public RegexRepository(DataContext context) : base(context) { }

        public async Task<IQueryable<string>> GetAllNamesAsync()
        {
            var regexes = await base.GetAllAsync();
            return regexes.Select(r => r.Name).Distinct();
        }
    }
}
