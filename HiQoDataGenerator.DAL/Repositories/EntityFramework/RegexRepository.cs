using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class RegexRepository : BaseRepository<Regex>, IRegexRepository
    {
        DataContext _context;
        RegexRepository(DataContext context) : base(context)
        {
            this._context = context;
        }

    }

}
