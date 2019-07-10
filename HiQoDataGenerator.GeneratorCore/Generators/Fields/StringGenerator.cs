using Bogus;
using Fare;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class StringGenerator : GeneratorBase, IFieldValueGenerator
    {
        public dynamic GenerateValue(IEnumerable<(ConstraintTypes type, dynamic value)> constraints)
        {
            int minLen = 0, maxLen = 127;
            string pattern = null;
            foreach (var (type, value) in constraints)
            {
                switch (type)
                {
                    case ConstraintTypes.MinLength:
                        minLen = (int)value;
                        break;
                    case ConstraintTypes.MaxLength:
                        maxLen = (int)value;
                        break;
                    case ConstraintTypes.Regex:
                        pattern = value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = (int)type };
                }
            }
            return pattern != null ? new Xeger(pattern).Generate() : _randomizer.String(minLen, maxLen);
        }

        public SupportedTypes FieldType { get => SupportedTypes.String; }
    }
}
