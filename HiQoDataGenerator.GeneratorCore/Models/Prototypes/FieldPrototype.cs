using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Models.Prototypes
{
    public class FieldPrototype
    {
        public string Name { get; }
        public bool IsRequired { get; }
        public int FieldTypeId { get; }
        public int? DatsetId { get; }
        public IEnumerable<ConstraintPrototype> Constraints { get; }

        public FieldPrototype(string name, bool isRequired, int fieldTypeId, int? datasetId, 
            IEnumerable<ConstraintPrototype> constraints = null)
        {
            Name = name;
            IsRequired = isRequired;
            FieldTypeId = fieldTypeId;
            DatsetId = datasetId;
            Constraints = constraints ?? new List<ConstraintPrototype>(); 
        }
    }
}
