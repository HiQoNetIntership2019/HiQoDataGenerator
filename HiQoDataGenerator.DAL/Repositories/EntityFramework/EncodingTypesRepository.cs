using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class EncodingTypesRepository: BaseRepository<EncodingType>
    {
        public EncodingTypesRepository(DataContext context) : base(context) { }
    }
}
