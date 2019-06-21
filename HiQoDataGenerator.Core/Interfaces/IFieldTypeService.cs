using System;
using System.Collections.Generic;
using System.Text;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFieldTypeService
    {
        IEnumerable<FieldTypeModel> GetAll();
        Task<FieldTypeModel> GetById(int id);
        Task<bool> Add(FieldTypeModel fieldTypeModel);
        Task<bool> RemoveById(int id);
    }
}
