using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IRegexService
    {
        IEnumerable<RegexModel> GetAll();
        IQueryable<string> GetAllNames();
        Task<RegexModel> GetByIdAsync(int id);
        Task<bool> AddAsync(RegexModel item);
        Task<bool> RemoveByIdAsync(int id);
    }
}
