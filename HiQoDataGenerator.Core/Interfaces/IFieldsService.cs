using HiQoDataGenerator.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFieldsService
    {
        Task<IEnumerable<FieldModel>> GetAllAsync();
        Task AddAsync(FieldModel model);
        Task<bool> RemoveByIdAsync(int id);
        Task<FieldModel> GetByIdAsync(int id);
    }
}
