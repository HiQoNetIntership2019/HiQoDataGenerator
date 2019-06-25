using System;
using System.Collections.Generic;
using System.Text;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IEncodingTypesService
    {
        IEnumerable<EncodingTypeModel> GetAll();
        Task<EncodingTypeModel> GetByIdAsync(int id);
        Task AddAsync(EncodingTypeModel encodingTypeModel);
        Task RemoveByIdAsync(int id);
    }
}
