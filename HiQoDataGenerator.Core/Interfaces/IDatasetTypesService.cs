using HiQoDataGenerator.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDatasetTypesService
    {
        Task<IEnumerable<DatasetTypeModel>> GetAllTypesAsync();
        Task AddTypeAsync(DatasetTypeModel datasetTypeModel);
        Task<bool> RemoveByIdAsync(int id);
        Task<DatasetTypeModel> GetByIdAsync(int id);
    }
}
