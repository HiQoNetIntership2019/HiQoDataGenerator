using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFileMetadataService
    {
        IEnumerable<FileMetadataModel> GetAll();
        Task<FileMetadataModel> GetByIdAsync(int id);
        Task<IEnumerable<FileMetadataModel>> GetByStatusId(int id);
        Task<IEnumerable<FileMetadataModel>> GetByStatusName(string name);

        Task UpdateAsync(FileMetadataModel fileMetadataModel);
        Task AddAsync(FileMetadataModel fileMetadataModel);
        Task RemoveAsync(int fileMetadataId);
    }
}
