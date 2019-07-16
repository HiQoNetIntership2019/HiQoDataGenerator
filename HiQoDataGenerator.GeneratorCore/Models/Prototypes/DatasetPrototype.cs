using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.GeneratorCore.Models.Prototypes
{
    public class DatasetPrototype
    {
        public int Id { get; }
        public ICollection<dynamic> Values { get; }

        public DatasetPrototype(int id, ICollection<dynamic> values)
        {
            Id = id;
            Values = values;
        }
    }
}
