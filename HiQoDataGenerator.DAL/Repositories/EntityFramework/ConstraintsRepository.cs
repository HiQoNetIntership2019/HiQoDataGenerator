using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class ConstraintsRepository: BaseRepository<Constraint>
    {
        public ConstraintsRepository(DataContext context) : base(context) { }
    }
}
