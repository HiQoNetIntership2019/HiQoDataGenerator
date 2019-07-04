﻿using System.Collections.Generic;
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

        public IEnumerable<DefinedDatasetValue> GetValues()
        {
            return _datasetValues.ToList();
        }

        public IEnumerable<DefinedDatasetValue> GetValuesByDatasetId(int datasetId)
        {
            var result = _datasetValues.Where(value => value.DatasetId == datasetId).ToList();
            return result.Count() == 0 ? null : result;
        }

        public IEnumerable<DefinedDatasetValue> GetValuesByDatasetName(string datasetName)
        {
            var result = _datasetValues.Include(v => v.Dataset).Where(value => value.Dataset.Name.ToLower() == datasetName).ToList();
            return result.Count() == 0 ? null : result;
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