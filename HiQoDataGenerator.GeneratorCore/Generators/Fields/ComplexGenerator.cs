using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;
using System.Numerics;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class ComplexGenerator : GeneratorBase, IFieldValueGenerator
    {
        public dynamic GenerateValue(IEnumerable<(ConstraintTypes, dynamic)> constraints)
        {
            double minA = double.MinValue, maxA = double.MaxValue, minB = double.MinValue, maxB = double.MaxValue;

            foreach (var (type, value) in constraints)
            {
                switch (type)
                {
                    case ConstraintTypes.MaxA:
                        maxA = (double)value;
                        break;
                    case ConstraintTypes.MinA:
                        minA = (double)value;
                        break;
                    case ConstraintTypes.MaxB:
                        maxB = (double)value;
                        break;
                    case ConstraintTypes.MinB:
                        minB = (double)value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = (int)type };
                }
            }

            return new Complex(_randomizer.Double(minA, maxA), _randomizer.Double(minB, maxB));
        }

        public SupportedTypes GetFieldType()
        {
            return SupportedTypes.Complex;
        }
    }
}
