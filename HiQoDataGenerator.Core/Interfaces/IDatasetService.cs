using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDatasetService
    {
        Task<IEnumerable<DatasetModel>> GetAllAsync();
        Task<DatasetModel> GetByIdAsync(int id);
        Task<DatasetModel> GetByNameAsync(string name);
        Task<IEnumerable<DatasetValueModel>> GetValuesByDatasetIdAsync(int id);
        Task<IEnumerable<DatasetValueModel>> GetValuesByDatasetNameAsync(string name);
        Task<IEnumerable<DatasetModel>> GetDatasetsByTypeIdAsync(int id);
        Task<IEnumerable<DatasetModel>> GetDatasetsByTypeNameAsync(string name);
        Task ToDefinedDatasetAsync(int datasetId);
    }
}
