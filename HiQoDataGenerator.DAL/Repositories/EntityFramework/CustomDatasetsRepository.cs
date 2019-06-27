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
            _datasetValues = context.Set<CustomDatasetValue>();
        }

        public IQueryable<CustomDatasetValue> GetAllValues()
        {
            return _datasetValues.Include(v => v.Dataset);
        }

        public IQueryable<CustomDatasetValue> GetValuesByDatasetId(int datasetId)
        {
            var result = _datasetValues.Where(value => value.DatasetId == datasetId).Include(v => v.Dataset);
            return result.Count() == 0 ? null : result;
        }

        public IQueryable<CustomDatasetValue> GetValuesByDatasetName(string datasetName)
        {
            var result = _datasetValues.Include(v => v.Dataset).Where(value => value.Dataset.Name.ToLower() == datasetName);
            return result.Count() == 0 ? null : result;
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
