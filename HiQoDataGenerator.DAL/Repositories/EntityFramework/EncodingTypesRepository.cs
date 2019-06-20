using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class EncodingTypesRepository: BaseRepository<EncodingType>
    {
        public EncodingTypesRepository(DataContext context) : base(context) { }
    }
}
