using System;
using System.Collections.Generic;
using System.Text;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFieldTypeService
    {
        IEnumerable<FieldTypeModel> GetAll();
    }
}
