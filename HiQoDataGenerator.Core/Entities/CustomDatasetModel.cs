using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetModel : BaseModel
    {
        public string Name { get; }
        
        public CustomDatasetModel(int id, string name) : base(id)
        {
            Name = name;
        }
    }
}
