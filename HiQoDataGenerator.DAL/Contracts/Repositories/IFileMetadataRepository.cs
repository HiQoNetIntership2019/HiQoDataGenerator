using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFileMetadataRepository : IGenericRepository<FileMetadata>
    {
        Task<IEnumerable<FileMetadata>> GetByStatusIdAsync(int id);
        Task<IEnumerable<FileMetadata>> GetByStatusIdAsync(int id, int count);
        Task<IEnumerable<FileMetadata>> GetByStatusNameAsync(string name);
        Task<IEnumerable<FileMetadata>> GetByStatusNameAsync(string name, int count);
    }
}
