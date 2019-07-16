using HiQoDataGenerator.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFileStatusService
    {
        IEnumerable<FileStatusModel> GetAll();
        Task<FileStatusModel> GetByIdAsync(int id);
        Task<FileStatusModel> GetByName(string name);
    }
}
