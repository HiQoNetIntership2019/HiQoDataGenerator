using System;
using System.Collections.Generic;
using System.Text;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFieldTypeService
    {
        IEnumerable<string> GetSupportedTypes();
        IEnumerable<FieldTypeModel> GetAll();
        Task<FieldTypeModel> GetByIdAsync(int id);
        Task AddAsync(FieldTypeModel fieldTypeModel);
        Task RemoveByIdAsync(int id);
    }
}
