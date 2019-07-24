using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IDefinedDatasetRepository : IGenericRepository<DefinedDataset>
    {
        Task<DefinedDataset> GetByNameAsync(string name);
        Task<IEnumerable<DefinedDatasetValue>> GetValuesAsync();
        Task<IEnumerable<DefinedDatasetValue>> GetValuesByDatasetIdAsync(int datasetId);
        Task<IEnumerable<DefinedDatasetValue>> GetValuesByDatasetNameAsync(string datasetName);
        Task<IEnumerable<DefinedDataset>> GetDatasetsByTypeIdAsync(int typeId);
        Task<IEnumerable<DefinedDataset>> GetDatasetsByTypeNameAsync(string typeName);

        Task AddValuesAsync(IEnumerable<DefinedDatasetValue> values);

        Task<bool> RemoveValueByIdAsync(int valueId);
    }
}
