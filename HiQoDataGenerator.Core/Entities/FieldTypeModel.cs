using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class FieldTypeModel : BaseModel
    {
        public string Name { get; }

        public FieldTypeModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
