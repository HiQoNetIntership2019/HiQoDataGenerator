using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IRegexService
    {
        Task<IEnumerable<RegexModel>> GetAllAsync();
        Task<IQueryable<string>> GetAllNamesAsync();
        Task<RegexModel> GetByIdAsync(int id);
        Task AddAsync(RegexModel item);
        Task<bool> RemoveByIdAsync(int id);
    }
}
