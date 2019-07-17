using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class FieldModel : BaseModel
    {
        public string Name { get; }
        public bool IsRequired { get; }
        public FieldTypeModel FieldType { get; }
        public ICollection<ConstraintValueModel> Constraints { get; }
        public DatasetModel Dataset { get; }

        public FieldModel(int id, string name, bool isRequired, FieldTypeModel fieldType, 
            ICollection<ConstraintValueModel> constraints, DatasetModel dataset = null) : base(id)
        {
            Name = name;
            IsRequired = isRequired;
            FieldType = fieldType;
            Constraints = constraints ?? new List<ConstraintValueModel>();
            Dataset = dataset;
        }
     
    }
}
