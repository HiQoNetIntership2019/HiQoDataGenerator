using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class DoubleGenerator : MinMaxGenerator<double, double>
    {
        public DoubleGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }

        public override SupportedTypes FieldType => SupportedTypes.Double;

        public override double Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            LoadConstraints(constraints);
            return _randomValueGenerator.GenerateDouble(_constraints[ConstraintTypes.Min], _constraints[ConstraintTypes.Max]);
        }
    }
}
