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
        protected readonly DbSet<CustomDatasetValue> _datasetValues;

        public CustomDatasetsRepository(DataContext context) : base(context)
        {
            _datasetValues = context.CustomDatasetsValues;
        }

        public async Task<CustomDataset> GetDatasetWithValues(int datasetId)
        {
            return await _models.Where(model => model.Id == datasetId).Include(d => d.CustomDatasetValues)?.FirstOrDefaultAsync();
        }

        public async Task<CustomDataset> GetDatasetWithValues(string datasetName)
        {
            return await _models.Where(model => model.Name == datasetName).Include(d => d.CustomDatasetValues)?.FirstOrDefaultAsync();
        }

        public async Task AddValueAsync(int datasetId,CustomDatasetValue value)
        {
            await _datasetValues.AddAsync(value);
        }

        public async Task AddValuesAsync(int datasetId, IEnumerable<CustomDatasetValue> values)
        {
            await _datasetValues.AddRangeAsync(values);
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
