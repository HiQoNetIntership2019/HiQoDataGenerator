using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Numerics;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class ComplexGenerator : GeneratorBase<Complex, double>
    {
        public override SupportedTypes FieldType => SupportedTypes.Complex;

        public ComplexGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        {
            Constraints[ConstraintTypes.MinA] = double.MinValue / 10;
            Constraints[ConstraintTypes.MinB] = double.MinValue / 10;
            Constraints[ConstraintTypes.MaxA] = double.MaxValue / 10;
            Constraints[ConstraintTypes.MaxB] = double.MaxValue / 10;
        }

        protected override Complex GenerateValue()
        {
            return RandomValueGenerator.GenerateComplex(Constraints[ConstraintTypes.MinA], Constraints[ConstraintTypes.MaxA],
                Constraints[ConstraintTypes.MinB], Constraints[ConstraintTypes.MaxB]);
        }
    }
}
