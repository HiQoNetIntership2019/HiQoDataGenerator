using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.FileMetadataModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FileMetadataRepository : GenericRepository<FileMetadata>, IFileMetadataRepository
    {
        public FileMetadataRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<FileMetadata>> GetByStatusId(int id)
        {
            var result = await Task.Run(() => _models.Where(model => model.StatusId == id).ToList());
            return result.Count() == 0 ? null : result;
        }

        public async Task<IEnumerable<FileMetadata>> GetByStatusName(string name)
        {
            var result = await Task.Run(() => _models.Include(model => model.Status).Where(model => model.Status.Status.ToLower() == name).ToList());
            return result.Count() == 0 ? null : result;
        }
    }
}
