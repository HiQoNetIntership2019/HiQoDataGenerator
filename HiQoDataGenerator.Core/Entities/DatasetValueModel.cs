using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class DatasetValueModel<T> : BaseModel
    {
        public T Value { get; set; }

        public DatasetValueModel(int id, T value) : base(id) => Value = value;
        public DatasetValueModel(T value) : this(0, value) { }

        public override string ToString() => Value.ToString();
    }
}
