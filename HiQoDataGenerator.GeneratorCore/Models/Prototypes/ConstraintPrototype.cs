namespace HiQoDataGenerator.GeneratorCore.Models.Prototypes
{
    public class ConstraintPrototype
    {
        public int TypeId { get; }
        public dynamic Value { get; } 

        public ConstraintPrototype(int typeId, dynamic value)
        {
            TypeId = typeId;
            Value = value;
        }
    }
}
