using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class StringGenerator : GeneratorBase<string, dynamic>, IFieldValueGenerator
    {
        public override SupportedTypes FieldType => SupportedTypes.String;

        public StringGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        {
            _constraints[ConstraintTypes.MinLength] = 0;
            _constraints[ConstraintTypes.MaxLength] = NumberConstants.MaxStringLength;
            _constraints[ConstraintTypes.Regex] = null;

        }

        public override string Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            LoadConstraints(constraints);
            return _constraints[ConstraintTypes.Regex] != null ?
                _randomValueGenerator.GenerateString(_constraints[ConstraintTypes.Regex]) :
                _randomValueGenerator.GenerateString(_constraints[ConstraintTypes.MinLength], _constraints[ConstraintTypes.MaxLength]);
        }
    }
}
