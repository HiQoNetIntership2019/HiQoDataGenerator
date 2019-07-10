using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class ByteGenerator : GeneratorBase, IFieldValueGenerator
    {
        public SupportedTypes FieldType { get => SupportedTypes.Byte; }

        public dynamic GenerateValue(IEnumerable<(ConstraintTypes type, dynamic value)> constraints)
        {
            byte min = byte.MinValue, max = byte.MaxValue;

            foreach (var (type, value) in constraints)
            {
                switch (type)
                {
                    case ConstraintTypes.Min:
                        min = (byte)value;
                        break;
                    case ConstraintTypes.Max:
                        max = (byte)value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException();
                }
            }

            return _randomizer.Byte(min, max);
        }
    }
}
