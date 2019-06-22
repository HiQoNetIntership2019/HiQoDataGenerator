using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities.Datasets
{
    public class DatasetModel<T> : BaseModel
    {
        public string Name { get; }
        public IEnumerable<DatasetValueModel<T>> Values { get; }
        public DatasetModel(int id, string name, IEnumerable<DatasetValueModel<T>> values) : base(id)
        {
            Name = name;
            Values = values;
        }
    }
}
