using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface ICustomDatasetRepository :IGenericRepository<CustomDataset>
    {
        Task<CustomDataset> GetDatasetByNameAsync(string name);
        Task<IQueryable<CustomDatasetValue>> GetValuesAsync();
        Task<IQueryable<CustomDatasetValue>> GetValuesByDatasetIdAsync(int datasetId);
        Task<IQueryable<CustomDatasetValue>> GetValuesByDatasetNameAsync(string datasetName);

        Task AddValuesAsync(IEnumerable<CustomDatasetValue> values);

        Task<bool> RemoveValueByIdAsync(int valueId);
    }
}
