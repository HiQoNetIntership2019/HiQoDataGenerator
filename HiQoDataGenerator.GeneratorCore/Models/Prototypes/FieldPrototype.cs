using HiQoDataGenerator.DAL.Restrictions;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Models.Prototypes
{
    public class FieldPrototype
    {
        public string Name { get; }
        public bool IsRequired { get; }
        public SupportedTypes Type { get; }
        public int? DatasetId { get; }
        public IEnumerable<ConstraintPrototype> Constraints { get; }

        public FieldPrototype(string name, bool isRequired, SupportedTypes type, int? datasetId, 
            IEnumerable<ConstraintPrototype> constraints = null)
        {
            Name = name;
            IsRequired = isRequired;
            Type = type;
            DatasetId = datasetId;
            Constraints = constraints ?? new List<ConstraintPrototype>(); 
        }
    }
}
