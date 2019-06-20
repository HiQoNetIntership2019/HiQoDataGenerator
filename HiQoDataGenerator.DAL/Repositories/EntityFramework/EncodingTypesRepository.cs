using System.Linq;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using System.Threading.Tasks;


namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class EncodingTypesRepository: BaseRepository<EncodingType>
    {
        public EncodingTypesRepository(DataContext context) : base(context) { }

    }
}
