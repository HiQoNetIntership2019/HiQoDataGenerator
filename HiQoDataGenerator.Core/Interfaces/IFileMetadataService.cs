using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFileMetadataService
    {
        Task<IEnumerable<FileMetadataModel>> GetAllAsync();
        Task<FileMetadataModel> GetByIdAsync(int id);
        Task<IEnumerable<FileMetadataModel>> GetByStatusIdAsync(int id);
        Task<IEnumerable<FileMetadataModel>> GetByStatusIdAsync(int id, int count);
        Task<IEnumerable<FileMetadataModel>> GetByStatusNameAsync(string name);
        Task<IEnumerable<FileMetadataModel>> GetByStatusNameAsync(string name, int count);

        Task UpdateAsync(FileMetadataModel fileMetadataModel);
        Task UpdateRangeAsync(IEnumerable<FileMetadataModel> fileMetadataModels);
        Task AddAsync(FileMetadataModel fileMetadataModel);
        Task RemoveAsync(int fileMetadataId);
    }
}
