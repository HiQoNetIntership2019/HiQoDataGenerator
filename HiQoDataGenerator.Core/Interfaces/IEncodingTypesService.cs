using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IEncodingTypesService
    {
        Task<IEnumerable<EncodingTypeModel>> GetAllAsync();
        Task<EncodingTypeModel> GetByIdAsync(int id);
        Task AddAsync(EncodingTypeModel encodingTypeModel);
        Task RemoveByIdAsync(int id);
    }
}
