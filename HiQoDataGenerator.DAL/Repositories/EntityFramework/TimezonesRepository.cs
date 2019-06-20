using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class TimezonesRepository : BaseRepository<TimezoneModel>, ITimezoneRepository
    {
        public TimezonesRepository(DataContext context) : base(context) { }
    }
}
