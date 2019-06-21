using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class ConstraintModel : BaseEntity
    {
        public string Name { get; }
        public string Description { get; }
        //public ICollection<FieldTypeModel> FieldTypes { get; set; }

        public ConstraintModel(string name, string description)
        {
            Name = name;
            Description = description;
            //FieldTypes = fieldTypes;
        }
    }
}
