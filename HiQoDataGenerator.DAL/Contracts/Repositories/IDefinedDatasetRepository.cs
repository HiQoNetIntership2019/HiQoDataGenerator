using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IDefinedDatasetRepository : IGenericRepository<DefinedDataset>
    {
        Task<DefinedDataset> GetByNameAsync(string name);
        IEnumerable<DefinedDatasetValue> GetValues();
        IEnumerable<DefinedDatasetValue> GetValuesByDatasetId(int datasetId);
        IEnumerable<DefinedDatasetValue> GetValuesByDatasetName(string datasetName);
        IEnumerable<DefinedDataset> GetDatasetsByTypeId(int typeId);
        IEnumerable<DefinedDataset> GetDatasetsByTypeName(string typeName);

        Task AddValuesAsync(IEnumerable<DefinedDatasetValue> values);

        Task<bool> RemoveValueByIdAsync(int valueId);
    }
}
