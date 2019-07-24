using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class CustomDatasetsRepository : GenericRepository<CustomDataset>, ICustomDatasetRepository
    {
        protected readonly DbSet<CustomDatasetValue> _datasetValues;
        
        public CustomDatasetsRepository(DataContext context) : base(context)
        {
            _datasetValues = context.Set<CustomDatasetValue>();
        }

        public async Task<CustomDataset> GetDatasetByNameAsync(string name)
        {
            return await Task.Run(() => _models.Where(model => model.Name.ToLower() == name).FirstOrDefault());
        }

        public async Task<IQueryable<CustomDatasetValue>> GetValuesAsync()
        {
            return await Task.Run(()=>_datasetValues);
        }

        public async Task<IQueryable<CustomDatasetValue>> GetValuesByDatasetIdAsync(int datasetId)
        {
            var result = await Task.Run(()=>_datasetValues.Where(value => value.DatasetId == datasetId));
            return !result.Any() ? null : result;
        }

        public async Task<IQueryable<CustomDatasetValue>> GetValuesByDatasetNameAsync(string datasetName)
        {
            var result = await  Task.Run(()=>_datasetValues.Include(v => v.Dataset).Where(value => value.Dataset.Name.ToLower() == datasetName));
            return !result.Any() ? null : result;
        }
        
        public async Task AddValuesAsync(IEnumerable<CustomDatasetValue> values)
        {
            await _datasetValues.AddRangeAsync(values);
        }

        public async Task AddDatasetWithValues(CustomDataset customDataset)
        {
            await _models.AddAsync(customDataset);
        }

        public async Task<bool> RemoveValueByIdAsync(int valueId)
        {
            var value = await _datasetValues.FindAsync(valueId);
            if (value == null)
            {
                return false;
            }
            _datasetValues.Remove(value);
            return true;
        }
    }
}
