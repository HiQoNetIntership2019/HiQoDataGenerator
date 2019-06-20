using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class TypesRepository : BaseRepository<FieldType>
    {
        public TypesRepository(DataContext context) : base(context) { }
    }
}
