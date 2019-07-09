using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Models.Objects
{
    public class GeneratedObject
    {
        public string Name { get; }
        public DateTime DateCreated { get; }
        public ICollection<GeneratedField> Fields { get; }


        public GeneratedObject(string name, ICollection<GeneratedField> fields = null)
        {
            Name = name;
            DateCreated = DateTime.Now;
            Fields = fields ?? new List<GeneratedField>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
