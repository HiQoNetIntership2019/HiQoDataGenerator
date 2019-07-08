namespace HiQoDataGenerator.GeneratorCore.Models.Prototypes
{
    public class ConstraintPrototype
    {
        public int TypeId { get; }
        public object Value { get; } 

        public ConstraintPrototype(int typeId, object value)
        {
            TypeId = typeId;
            Value = value;
        }
    }
}
