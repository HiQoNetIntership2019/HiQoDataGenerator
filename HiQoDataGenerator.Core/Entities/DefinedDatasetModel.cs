using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class DefinedDatasetModel : BaseModel
    {
        public string Name { get; }
        public int TypeId { get; }
        public IEnumerable<DefinedDatasetValueModel> Values { get; set; }

        public DefinedDatasetModel(int id, string name, int typeId) : base(id)
        {
            Name = name;
            TypeId = typeId;
        }

        public DefinedDatasetModel(int id, string name, int typeId, ICollection<DefinedDatasetValueModel> values) : base(id)
        {
            Name = name;
            TypeId = typeId;
            Values = values;
        }
    }
}
