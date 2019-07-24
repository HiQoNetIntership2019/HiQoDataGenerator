using HiQoDataGenerator.DAL.Models.IntermediateModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FieldTypesConstraintsRepository : GenericRepository<FieldTypeConstraint>, IFieldTypesConstraintsRepository
    {
        public FieldTypesConstraintsRepository(DataContext context) : base(context) { }
    }
}
