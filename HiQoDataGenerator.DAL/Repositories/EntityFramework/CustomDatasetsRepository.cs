using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class CustomDatasetsRepository : BaseRepository<CustomDataset>, ICustomDatasetRepository
    {
        public CustomDatasetsRepository(DataContext context) : base(context) { }

        public CustomDataset GetDatasetWithValues(int datasetId)
        {
            return _models.Where(model => model.Id == datasetId).Include(d => d.CustomDatasetValues)?.FirstOrDefault();
        }

        public CustomDataset GetDatasetWithValues(string datasetName)
        {
            return _models.Where(model => model.Name == datasetName).Include(d => d.CustomDatasetValues)?.FirstOrDefault();
        }

        public Task AddValueAsync(CustomDatasetValue value)
        {
            throw new System.NotImplementedException();
        }

        public Task AddValuesAsync(IEnumerable<CustomDatasetValue> values)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveAllValuesAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveValueAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
