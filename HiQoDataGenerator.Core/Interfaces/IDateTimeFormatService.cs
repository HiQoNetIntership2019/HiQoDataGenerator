using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDateTimeFormatService
    {
        IEnumerable<DateTimeFormatModel> GetAll();
        Task<DateTimeFormatModel> GetByIdAsync(int id);
        Task<bool> AddAsync(DateTimeFormatModel dateTimeFormatModel);
        Task<bool> AddRangeAsync(IEnumerable<DateTimeFormatModel> dateTimeFormatModels);
        Task<bool> RemoveByIdAsync(int id);
    }
}
