using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDefinedDatasetService
    {
        IEnumerable<DefinedDatasetModel> GetAll();
        Task<DefinedDatasetModel> GetByIdAsync(int id);
        IEnumerable<DefinedDatasetValueModel> GetValues();
        IEnumerable<DefinedDatasetValueModel> GetValuesByDatasetId(int id);
        IEnumerable<DefinedDatasetValueModel> GetValuesByDatasetName(string name);

        Task AddValuesAsync(IEnumerable<DefinedDatasetValueModel> definedDatasetValueModels);
        Task AddAsync(DefinedDatasetModel definedDatasetModel);
        Task RemoveDatasetAsync(int datasetId);
        Task RemoveValueByIdAsync(int valueId);
    }
}
