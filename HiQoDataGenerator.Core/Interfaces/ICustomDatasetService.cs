using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface ICustomDatasetService
    {
        IEnumerable<CustomDatasetModel> GetAll();
        IEnumerable<CustomDatasetValueModel> GetAllValues();
        Task<CustomDatasetModel> GetByIdAsync(int id);
        Task AddAsync(CustomDatasetModel customDatasetModel);
        Task AddRangeAsync(IEnumerable<CustomDatasetModel> customDatasetModels);
        Task RemoveByIdAsync(int id);
    }
}
