using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.FileMetadataModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FileStatusRepository : GenericRepository<FileStatus>, IFileStatusRepository
    {
        public FileStatusRepository(DataContext context) : base(context) { }
    }
}
