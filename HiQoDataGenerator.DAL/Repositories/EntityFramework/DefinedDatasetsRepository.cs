using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DefinedDatasetsRepository : GenericRepository<DefinedDataset>, IDefinedDatasetRepository
    {
        protected readonly DbSet<DefinedDatasetValue> _datasetValues;

        public DefinedDatasetsRepository(DataContext context) : base(context)
        {
            _datasetValues = context.Set<DefinedDatasetValue>();
        }

        public async Task<DefinedDataset> GetByNameAsync(string name)
        {
            return await Task.Run(() => _models.Where(model => model.Name.ToLower() == name).FirstOrDefault());
        }

        public async Task<IEnumerable<DefinedDatasetValue>> GetValuesAsync()
        {
            return await _datasetValues.ToListAsync();
        }

        public async Task<IEnumerable<DefinedDatasetValue>> GetValuesByDatasetIdAsync(int datasetId)
        {
            var result = await _datasetValues.Where(value => value.DatasetId == datasetId).ToListAsync();
            return !result.Any() ? null : result;
        }

        public async Task<IEnumerable<DefinedDatasetValue>> GetValuesByDatasetNameAsync(string datasetName)
        {
            var result = await _datasetValues.Include(v => v.Dataset).Where(value => value.Dataset.Name.ToLower() == datasetName).ToListAsync();
            return !result.Any() ? null : result;
        }

        public async Task<IEnumerable<DefinedDataset>> GetDatasetsByTypeIdAsync(int typeId)
        {
            var result = await _models.Where(model => model.TypeId == typeId).ToListAsync();
            return !result.Any() ? null : result;
        }

        public async Task<IEnumerable<DefinedDataset>> GetDatasetsByTypeNameAsync(string typeName)
        {
            var result = await _models.Include(model => model.Type).Where(model => model.Type.Name == typeName).ToListAsync();
            return !result.Any() ? null : result;
        }

        public async Task AddValuesAsync(IEnumerable<DefinedDatasetValue> values)
        {
            await _datasetValues.AddRangeAsync(values);
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
