using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FieldTypesRepository : BaseRepository<FieldType>,IFieldTypeRepository
    {
        public FieldTypesRepository(DataContext context) : base(context) { }
    }
}
