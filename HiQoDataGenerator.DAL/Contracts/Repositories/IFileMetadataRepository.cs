using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFileMetadataRepository : IGenericRepository<FileMetadata>
    {
        Task<IEnumerable<FileMetadata>> GetByStatusId(int id);
        Task<IEnumerable<FileMetadata>> GetByStatusName(string name);
    }
}
