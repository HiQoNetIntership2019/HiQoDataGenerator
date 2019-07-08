using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class DoubleGenerator : GeneratorBase, IFieldValueGenerator
    {
        public dynamic GenerateValue(IEnumerable<(ConstraintTypes, dynamic)> constraints)
        {
            double minValue = double.MinValue, maxValue = double.MaxValue;
            foreach (var (type, value) in constraints)
            {
                switch (type)
                {
                    case ConstraintTypes.Min:
                        minValue = value;
                        break;
                    case ConstraintTypes.Max:
                        maxValue = value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = (int)type };
                }
            }
            return _randomizer.Double(minValue, maxValue);
        }

        public SupportedTypes GetFieldType()
        {
            return SupportedTypes.Double;
        }
    }
}
