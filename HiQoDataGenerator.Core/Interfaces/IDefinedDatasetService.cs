using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDefinedDatasetService
    {
        Task<IEnumerable<DefinedDatasetModel>> GetAllAsync();
        Task<DefinedDatasetModel> GetByIdAsync(int id);
        Task<IEnumerable<DefinedDatasetValueModel>> GetValuesAsync();
        Task<IEnumerable<DefinedDatasetValueModel>> GetValuesByDatasetIdAsync(int id);
        Task<IEnumerable<DefinedDatasetValueModel>> GetValuesByDatasetNameAsync(string name);
        Task<IEnumerable<DefinedDatasetModel>> GetDatasetsByTypeIdAsync(int id);
        Task<IEnumerable<DefinedDatasetModel>> GetDatasetsByTypeNameAsync(string name);
        Task<DefinedDatasetModel> GetDatasetWithValuesByIdAsync(int id);

        Task AddValuesAsync(IEnumerable<DefinedDatasetValueModel> definedDatasetValueModels);
        Task AddAsync(DefinedDatasetModel definedDatasetModel);
        Task<bool> RemoveDatasetAsync(int datasetId);
        Task<bool> RemoveValueByIdAsync(int valueId);
    }
}
