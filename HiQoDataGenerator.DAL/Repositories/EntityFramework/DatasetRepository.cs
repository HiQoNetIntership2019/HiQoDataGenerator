using System.Threading.Tasks;
using System.Linq;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class DatasetRepository : GenericRepository<Dataset>, IDatasetRepository
    {
        public DatasetRepository(DataContext context) : base(context) { }
        
        public async Task<Dataset> GetByNameAsync(string name)
        {
            return await Task.Run(() => _models.Where(model => model.Name.ToLower() == name).FirstOrDefault());
        }

        public async Task<IEnumerable<Dataset>> GetDatasetsByTypeIdAsync(int id)
        {
            var result = await Task.Run(() => _models.Where(model => model.TypeId == id).ToList());
            return !result.Any() ? null : result;
        }

        public async Task<IEnumerable<Dataset>> GetDatasetsByTypeNameAsync(string name)
        {
            var result = await Task.Run(() => _models.Include(model => model.Type).Where(model => model.Type.Name == name).ToList());
            return !result.Any() ? null : result;
        }

        public async Task ToDefinedDatasetAsync(int datasetId)
        {
            var dataset = await _models.FindAsync(datasetId);
            if (dataset != null)
                dataset.IsDefined = true;
        }
    }
}
