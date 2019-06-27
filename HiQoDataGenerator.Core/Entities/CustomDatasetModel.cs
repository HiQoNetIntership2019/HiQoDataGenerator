using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetModel : BaseModel
    {
        public string Name { get; }

        public ICollection<CustomDatasetValueModel> Values;

        public CustomDatasetModel(int id, string name, ICollection<CustomDatasetValueModel> values) : base(id)
        {
            Name = name;
            Values = values;
        }
    }
}
