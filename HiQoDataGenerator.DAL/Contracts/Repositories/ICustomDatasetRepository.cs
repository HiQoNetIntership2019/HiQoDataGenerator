using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface ICustomDatasetRepository :IBaseRepository<CustomDataset>
    {
        IQueryable<CustomDatasetValue> GetDatasetValues(int datasetId);
        IQueryable<CustomDatasetValue> GetDatasetValues(string datasetName);
        Task AddValueAsync(CustomDatasetValue value);
        Task AddValuesAsync(IEnumerable<CustomDatasetValue> values);
        Task<bool> RemoveValueAsync(int id);
        Task<bool> RemoveAllValuesAsync(int id);
    }
}
