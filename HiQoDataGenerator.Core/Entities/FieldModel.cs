using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class FieldModel : BaseModel
    {
        public string Name { get; }

        public bool IsRequired { get; }

        public FieldTypeModel FieldType { get; }

        public IEnumerable<ConstraintValueModel> Constraints { get; }

        public FieldModel(int id, string name, bool isRequired, FieldTypeModel fieldType, 
            IEnumerable<ConstraintValueModel> constraints) : base(id)
        {
            Name = name;
            IsRequired = isRequired;
            FieldType = fieldType;
            Constraints = constraints;
        }

        public FieldModel(int id, string name, bool isRequired) : this(id, name, isRequired, null, null) { }
    }
}
