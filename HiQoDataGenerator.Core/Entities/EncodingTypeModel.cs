using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class EncodingTypeModel: BaseEntity
    {
        public string Name { get; }

        public EncodingTypeModel(string name) => Name = name;
    }
}
