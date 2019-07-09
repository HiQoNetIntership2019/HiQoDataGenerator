namespace HiQoDataGenerator.GeneratorCore.Models.Objects
{
    public class GeneratedField
    {
        public string Name { get; }
        public dynamic Value { get; }

        public GeneratedField(string name, dynamic value)
        {
            Name = name;
            Value = value;
        }
    }
}
