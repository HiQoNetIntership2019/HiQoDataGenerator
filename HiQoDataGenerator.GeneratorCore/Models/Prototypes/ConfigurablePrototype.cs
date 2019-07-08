using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Models.Prototypes
{
    public class ConfigurablePrototype : IPrototype
    {
        public string Name { get; }
        public IEnumerable<FieldPrototype> Fields { get; }

        public ConfigurablePrototype(string name, IEnumerable<FieldPrototype> fields = null)
        {
            Name = name;
            Fields = fields ?? new List<FieldPrototype>();
        }
    }
}
