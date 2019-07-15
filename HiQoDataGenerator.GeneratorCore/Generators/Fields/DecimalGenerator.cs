using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class DecimalGenerator : GeneratorBase<decimal, int>
    {
        public override SupportedTypes FieldType => SupportedTypes.Decimal;
        
        public DecimalGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        {
            _constraints[ConstraintTypes.MaxDigits] = NumberConstants.MaxDigitsInDecimal;
            _constraints[ConstraintTypes.DecimalPlace] = 0;
        }

        public override decimal Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            LoadConstraints(constraints);
            return _randomValueGenerator.GenerateDecimal(_constraints[ConstraintTypes.MaxDigits], _constraints[ConstraintTypes.DecimalPlace]);
        }
    }
}
