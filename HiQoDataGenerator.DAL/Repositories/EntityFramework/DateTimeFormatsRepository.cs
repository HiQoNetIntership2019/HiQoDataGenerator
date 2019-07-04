using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DateTimeFormatsRepository : GenericRepository<DateTimeFormat>, IDateTimeFormatRepository
    {
        public DateTimeFormatsRepository(DataContext context) : base(context) { }
    }
}
