using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class EncodingTypesRepository: GenericRepository<EncodingType>, IEncodingTypeRepository
    {
        public EncodingTypesRepository(DataContext context) : base(context) { }
    }
}
