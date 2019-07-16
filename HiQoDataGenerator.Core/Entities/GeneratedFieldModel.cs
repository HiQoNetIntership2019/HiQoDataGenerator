using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class GeneratedFieldModel : BaseModel
    {
        public string Name { get; }
        public dynamic Value { get; }

        public GeneratedFieldModel(int id, string name, dynamic value) : base(id)
        {
            Name = name;
            Value = value;
        }
    }
}
