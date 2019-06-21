using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class TimezonesService : BaseRepository<Timezone>, ITimezoneRepository
    {
        public TimezonesService(DataContext context) : base(context) { }
    }
}
