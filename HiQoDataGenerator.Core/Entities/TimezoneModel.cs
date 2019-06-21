using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class TimezoneModel : BaseModel
    {
        public string Value { get; }

        public TimezoneModel(string value) => Value = value;
    }
}
