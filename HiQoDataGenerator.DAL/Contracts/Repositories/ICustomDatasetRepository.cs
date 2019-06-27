using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface ICustomDatasetRepository :IBaseRepository<CustomDataset>
    {
        Task<CustomDataset> GetDatasetWithValues(int datasetId);
        Task<CustomDataset> GetDatasetWithValues(string datasetName);
        Task AddValueAsync(int datasetId, CustomDatasetValue value);
        Task AddValuesAsync(int datasetId, IEnumerable<CustomDatasetValue> values);
        Task<bool> RemoveValueAsync(int id);
        Task<bool> RemoveAllValuesAsync(int id);
    }
}
