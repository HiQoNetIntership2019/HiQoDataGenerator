using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class DoubleGenerator : MinMaxGenerator<double, dynamic>
    {
        public DoubleGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }

        public override SupportedTypes FieldType => SupportedTypes.Double;

        protected override double GenerateValue()
        {
            return RandomValueGenerator.GenerateDouble(Constraints[ConstraintTypes.Min], Constraints[ConstraintTypes.Max]);

        }
    }
}
