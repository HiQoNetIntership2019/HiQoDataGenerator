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
        
        public async Task<IEnumerable<FileMetadata>> GetByStatusIdAsync(int id)
        {
            var result = await Task.Run(() => _models.Where(model => model.StatusId == id).AsNoTracking().ToList());
            return !result.Any() ? null : result;
        }

        public async Task<IEnumerable<FileMetadata>> GetByStatusIdAsync(int id,int count)
        {
            var result = await Task.Run(() => _models.Where(model => model.StatusId == id).Take(count).AsNoTracking().ToList());
            return !result.Any() ? null : result;
        }

        public async Task<IEnumerable<FileMetadata>> GetByStatusNameAsync(string name)
        {
            var result = await Task.Run(() => _models.Include(model => model.Status)
                .Where(model => model.Status.Status.ToLower() == name).AsNoTracking().ToList());
            return !result.Any() ? null : result;
        }

        public async Task<IEnumerable<FileMetadata>> GetByStatusNameAsync(string name, int count)
        {
            var result = await Task.Run(() => _models.Include(model => model.Status)
                .Where(model => model.Status.Status.ToLower() == name)
                .Take(count).AsNoTracking().ToList());
            return !result.Any() ? null : result;
        }
    }
}
