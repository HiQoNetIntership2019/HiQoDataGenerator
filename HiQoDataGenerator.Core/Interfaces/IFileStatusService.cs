using HiQoDataGenerator.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFileStatusService
    {
        Task<IEnumerable<FileStatusModel>> GetAllAsync();
        Task<FileStatusModel> GetByIdAsync(int id);
        Task<FileStatusModel> GetByNameAsync(string name);
    }
}
