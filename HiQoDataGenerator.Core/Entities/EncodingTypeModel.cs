using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class EncodingTypeModel: BaseModel
    {
        public string Name { get; }

        public EncodingTypeModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
