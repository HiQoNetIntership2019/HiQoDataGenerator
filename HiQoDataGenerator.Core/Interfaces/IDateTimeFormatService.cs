using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDateTimeFormatService
    {
        Task<IEnumerable<DateTimeFormatModel>> GetAllAsync();
        Task<DateTimeFormatModel> GetByIdAsync(int id);
        Task AddAsync(DateTimeFormatModel dateTimeFormatModel);
        Task AddRangeAsync(IEnumerable<DateTimeFormatModel> dateTimeFormatModels);
        Task<bool> RemoveByIdAsync(int id);
    }
}
