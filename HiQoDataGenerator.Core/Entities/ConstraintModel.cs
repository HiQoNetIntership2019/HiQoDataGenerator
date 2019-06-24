using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class ConstraintModel : BaseModel
    {
        public string Name { get; }
        public string Description { get; }
        //public ICollection<FieldTypeModel> FieldTypes { get; set; }

        public ConstraintModel(int id, string name, string description) : base(id)
        {
            Name = name;
            Description = description;
            //FieldTypes = fieldTypes;
        }
    }
}
