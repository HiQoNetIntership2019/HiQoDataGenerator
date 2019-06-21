using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class FieldTypeModel : BaseModel
    {
        public string Name { get; }

        public FieldTypeModel(string name)
        {
            Name = name;
        }
    }
}
