using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class CustomDatasetsRepository : BaseRepository<CustomDataset>, ICustomDatasetRepository
    {
        public CustomDatasetsRepository(DataContext context) : base(context) { }


    }
}
