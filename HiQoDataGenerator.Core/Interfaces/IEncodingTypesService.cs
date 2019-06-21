using HiQoDataGenerator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IEncodingTypesService
    {
        IEnumerable<EncodingTypeModel> GetAll();
        Task<EncodingTypeModel> GetByIdAsync(int id);
        //Task<bool> Add(EncodingTypeModel item);
    }
}
