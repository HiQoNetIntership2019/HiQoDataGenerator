using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class TimezonesService : BaseRepository<TimezoneModel>, ITimezoneRepository
    {
        public TimezonesService(DataContext context) : base(context) { }
    }
}
