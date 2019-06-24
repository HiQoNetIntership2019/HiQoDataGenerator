using System;
using System.Collections.Generic;
using System.Text;


namespace HiQoDataGenerator.Core.Entities
{
    public class RegexModel: BaseModel
    {
        public string Name { get; set; }
        
        public string Value { get; set; }

        public RegexModel(string name, string value, int id):base(id)
        {
            Name = name;
            Value = value;
        }
    }
}
