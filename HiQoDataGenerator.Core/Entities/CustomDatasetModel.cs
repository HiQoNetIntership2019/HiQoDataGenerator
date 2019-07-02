using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetModel : BaseModel
    {
        public string Name { get; }        
        public IEnumerable<CustomDatasetValueModel> Values { get; set; }

        public CustomDatasetModel(int id, string name) : base(id)
        {
            Name = name;
        }

        public CustomDatasetModel(int id, string name, ICollection<CustomDatasetValueModel> values) : base(id)
        {
            Name = name;
            Values = values;
        }
    }
}
