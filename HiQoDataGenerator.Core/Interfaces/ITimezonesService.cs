using HiQoDataGenerator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IFieldTypeService
    {
        IEnumerable<TimezoneModel> GetAll();
    }
}
