using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class TimezonesRepository : BaseRepository<Timezone>, ITimezoneRepository
    {
        public TimezonesRepository(DataContext context) : base(context) { }
    }
}
