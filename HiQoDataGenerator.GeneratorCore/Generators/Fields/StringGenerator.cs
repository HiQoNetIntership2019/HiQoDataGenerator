using System.Collections.Generic;
using System.Text;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class StringGenerator : GeneratorBase<string, dynamic>
    {
        private readonly Dictionary<string, Encoding> _encodingConverter = new Dictionary<string, Encoding>();
        public override SupportedTypes FieldType => SupportedTypes.String;

        public StringGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        {
            Constraints[ConstraintTypes.MinLength] = 0;
            Constraints[ConstraintTypes.MaxLength] = NumberConstants.MaxStringLength;
            Constraints[ConstraintTypes.Regex] = null;
            Constraints[ConstraintTypes.Encoding] = null;

            _encodingConverter[StringConstants.UTF8Key] = Encoding.UTF8;
            _encodingConverter[StringConstants.UTF16Key] = Encoding.Unicode;
            _encodingConverter[StringConstants.UTF32Key] = Encoding.UTF32;
        }

        protected override string GenerateValue()
        {
            var result = Constraints[ConstraintTypes.Regex] != null
                ? RandomValueGenerator.GenerateString(Constraints[ConstraintTypes.Regex])
                : RandomValueGenerator.GenerateString((int) Constraints[ConstraintTypes.MinLength],
                    (int) Constraints[ConstraintTypes.MaxLength]);

            var encoding = _encodingConverter[Constraints[ConstraintTypes.Encoding]];

            return encoding?.GetString(Encoding.Default.GetBytes(result)) ?? result;
        }
    }
}
