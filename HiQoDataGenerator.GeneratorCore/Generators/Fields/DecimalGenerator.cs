using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class DecimalGenerator : GeneratorBase<decimal, dynamic>
    {
        public override SupportedTypes FieldType => SupportedTypes.Decimal;
        
        public DecimalGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        {
            Constraints[ConstraintTypes.MaxDigits] = NumberConstants.MaxDigitsInDecimal;
            Constraints[ConstraintTypes.DecimalPlace] = 0;
            Constraints[ConstraintTypes.Separator] = ",";
        }

        protected override decimal GenerateValue()
        {
            return RandomValueGenerator.GenerateDecimal(Constraints[ConstraintTypes.MaxDigits], 
                Constraints[ConstraintTypes.DecimalPlace]);
        }
    }
}
