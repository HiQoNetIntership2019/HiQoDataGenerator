using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class Timezone : BaseEntity
    {
        public string Value { get; }

        public Timezone(string value) => Value = value;
    }
}
