using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface ICustomDatasetService
    {
        Task<IEnumerable<CustomDatasetModel>> GetAllAsync();
        Task<CustomDatasetModel> GetByIdAsync(int id);
        Task<IEnumerable<CustomDatasetValueModel>> GetValuesAsync();
        Task<IEnumerable<CustomDatasetValueModel>> GetValuesByDatasetIdAsync(int id);
        Task<IEnumerable<CustomDatasetValueModel>> GetValuesByDatasetNameAsync(string name);
        Task<CustomDatasetModel> GetDatasetWithValuesByIdAsync(int id);

        Task AddValuesAsync(IEnumerable<CustomDatasetValueModel> customDatasetValueModels);
        Task AddAsync(CustomDatasetModel customDatasetModel);
        Task<bool> RemoveDatasetAsync(int datasetId);
        Task<bool> RemoveValueByIdAsync(int valueId);
    }
}
