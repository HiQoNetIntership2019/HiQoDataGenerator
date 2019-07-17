using System.Collections.Generic;

namespace HiQoDataGenerator.Core.Entities
{
    public class FieldModel : BaseModel
    {
        public string Name { get; }
        public bool IsRequired { get; }
        public FieldTypeModel FieldType { get; }
        public ICollection<ConstraintValueModel> Constraints { get; }
        public int? DatasetId { get; }

        public FieldModel(int id, string name, bool isRequired, FieldTypeModel fieldType, 
            ICollection<ConstraintValueModel> constraints, int? datasetId = null) : base(id)
        {
            Name = name;
            IsRequired = isRequired;
            FieldType = fieldType;
            Constraints = constraints ?? new List<ConstraintValueModel>();
            DatasetId = datasetId;
        }
     
    }
}
