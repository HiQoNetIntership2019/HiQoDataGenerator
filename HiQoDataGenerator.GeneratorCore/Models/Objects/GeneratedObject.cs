using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Models.Objects
{
    public class GeneratedObject
    {
        public string Name { get; }
        public DateTime DateCreated { get; }
        public ICollection<(string Name, object Value)> Fields { get; }


        public GeneratedObject(string name, ICollection<(string, object)> fields = null)
        {
            Name = name;
            DateCreated = DateTime.Now;
            Fields = fields ?? new List<(string, object)>();
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
