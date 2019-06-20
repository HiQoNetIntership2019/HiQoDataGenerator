using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class RegexRepository : BaseRepository<Regex>
    {
        public RegexRepository(DataContext context) : base(context) { }
    }

}
