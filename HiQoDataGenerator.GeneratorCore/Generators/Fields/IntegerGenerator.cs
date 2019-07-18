using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class IntegerGenerator : MinMaxGenerator<int, int>
    {
        public IntegerGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }

        public override SupportedTypes FieldType => SupportedTypes.Int;

        protected override int GenerateValue()
        {
            return RandomValueGenerator.GenerateInt(Constraints[ConstraintTypes.Min], Constraints[ConstraintTypes.Max]);
        }
    }
}
