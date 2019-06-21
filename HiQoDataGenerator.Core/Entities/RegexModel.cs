using System;
using System.Collections.Generic;
using System.Text;


namespace HiQoDataGenerator.Core.Entities
{
    public class RegexModel: BaseEntity
    {
        public string Name { get; set; }
        
        public string Value { get; set; }

        public RegexModel(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
