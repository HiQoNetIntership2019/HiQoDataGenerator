using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFileStatusRepository : IGenericRepository<FileStatus>
    {
        Task<FileStatus> GetByNameAsync(string name);
    }
}
