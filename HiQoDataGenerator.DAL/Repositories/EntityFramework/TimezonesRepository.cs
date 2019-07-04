using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class TimezonesRepository : GenericRepository<Timezone>, ITimezoneRepository
    {
        public TimezonesRepository(DataContext context) : base(context) { }
    }
}
