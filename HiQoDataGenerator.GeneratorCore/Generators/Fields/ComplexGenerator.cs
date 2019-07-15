using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;
using System.Numerics;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class ComplexGenerator : GeneratorBase<Complex, double>
    {
        public override SupportedTypes FieldType => SupportedTypes.Complex;

        public ComplexGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        {
            _constraints[ConstraintTypes.MinA] = double.MinValue;
            _constraints[ConstraintTypes.MinB] = double.MinValue;
            _constraints[ConstraintTypes.MaxA] = double.MaxValue;
            _constraints[ConstraintTypes.MaxB] = double.MaxValue;
        }

        public override Complex Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            LoadConstraints(constraints);
            return _randomValueGenerator.GenerateComplex(_constraints[ConstraintTypes.MinA], _constraints[ConstraintTypes.MaxA],
                _constraints[ConstraintTypes.MinB], _constraints[ConstraintTypes.MaxB]);
        }
    }
}
