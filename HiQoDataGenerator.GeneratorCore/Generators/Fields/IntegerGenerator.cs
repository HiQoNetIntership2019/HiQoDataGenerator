using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class IntegerGenerator : MinMaxGenerator<int, int>, IFieldValueGenerator
    {
        public IntegerGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }

        public override SupportedTypes FieldType => SupportedTypes.Int;

        public override int Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            LoadConstraints(constraints);
            return _randomValueGenerator.GenerateInt(_constraints[ConstraintTypes.Min], _constraints[ConstraintTypes.Max]);
        }
    }
}
