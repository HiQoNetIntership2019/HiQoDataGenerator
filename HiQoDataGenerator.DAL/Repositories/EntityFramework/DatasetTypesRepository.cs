using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DatasetTypesRepository : GenericRepository<DatasetType>, IDatasetTypesRepository
    {
        public DatasetTypesRepository(DataContext context) : base(context) { }
    }
}
