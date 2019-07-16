using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class ByteGenerator : MinMaxGenerator<byte, byte>
    {
        public ByteGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }

        public override SupportedTypes FieldType => SupportedTypes.Byte;

        protected override byte GenerateValue()
        {
            return RandomValueGenerator.GenerateByte(Constraints[ConstraintTypes.Min], Constraints[ConstraintTypes.Max]);
        }
    }
}
