using System.Linq;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
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
