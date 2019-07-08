using HiQoDataGenerator.GeneratorCore.Extensions;

namespace HiQoDataGenerator.GeneratorCore.Models.Prototypes
{
    public class ConstraintPrototype
    {
        public ConstraintTypes Type { get; }
        public dynamic Value { get; } 

        public ConstraintPrototype(ConstraintTypes type, dynamic value)
        {
            Type = type;
            Value = value;
        }
    }
}
