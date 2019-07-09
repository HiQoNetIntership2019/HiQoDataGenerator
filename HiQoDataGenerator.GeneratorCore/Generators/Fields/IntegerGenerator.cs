using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class IntegerGenerator : GeneratorBase, IFieldValueGenerator
    {
        public dynamic GenerateValue(IEnumerable<(ConstraintTypes, dynamic)> constraints)
        {
            int minValue = int.MinValue, maxValue = int.MaxValue;
            foreach (var (type, value) in constraints)
            {
                switch (type)
                {
                    case ConstraintTypes.Min:
                        minValue = (int)value;
                        break;
                    case ConstraintTypes.Max:
                        maxValue = (int)value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = (int)type };
                }
            }
            return _randomizer.Int(minValue, maxValue);
        }

        public SupportedTypes GetFieldType()
        {
            return SupportedTypes.Int;
        }
    }
}
