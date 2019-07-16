using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.FileMetadataModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FileStatusRepository : GenericRepository<FileStatus>, IFileStatusRepository
    {
        public FileStatusRepository(DataContext context) : base(context) { }

        public async Task<FileStatus> GetByName(string name)
        {
            return await Task.Run(() => _models.Where(model => model.Status.ToLower() == name).FirstOrDefault());
        }
    }
}
