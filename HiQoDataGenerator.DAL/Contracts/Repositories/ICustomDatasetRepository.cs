using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface ICustomDatasetRepository :IBaseRepository<CustomDataset>
    {
        IQueryable<CustomDatasetValue> GetValues();
        IQueryable<CustomDatasetValue> GetValuesByDatasetId(int datasetId);
        IQueryable<CustomDatasetValue> GetValuesByDatasetName(string datasetName);

        Task AddValuesAsync(IEnumerable<CustomDatasetValue> values);

        Task<bool> RemoveValueByIdAsync(int valueId);
    }
}
