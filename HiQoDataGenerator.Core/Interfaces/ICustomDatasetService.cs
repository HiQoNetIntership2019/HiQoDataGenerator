using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface ICustomDatasetService
    {
        IEnumerable<CustomDatasetModel> GetAll();
        Task<CustomDatasetModel> GetByIdAsync(int id);
        IEnumerable<CustomDatasetValueModel> GetValues();
        IEnumerable<CustomDatasetValueModel> GetValuesByDatasetId(int id);
        IEnumerable<CustomDatasetValueModel> GetValuesByDatasetName(string name);

        Task AddValuesAsync(IEnumerable<CustomDatasetValueModel> customDatasetValueModels);
        Task AddAsync(CustomDatasetModel customDatasetModel);
        Task RemoveDatasetAsync(int datasetId);
        Task RemoveValueByIdAsync(int valueId);
    }
}
