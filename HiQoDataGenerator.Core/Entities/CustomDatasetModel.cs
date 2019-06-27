using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetModel : BaseModel
    {
        public string Name { get; }

        public IEnumerable<CustomDatasetValueModel> Values;

        public CustomDatasetModel(int id, string name, IEnumerable<CustomDatasetValueModel> values) : base(id)
        {
            Name = name;
            Values = values;
        }
    }
}
