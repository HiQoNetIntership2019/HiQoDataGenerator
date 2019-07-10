﻿using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class DecimalGenerator : GeneratorBase, IFieldValueGenerator
    {
        public dynamic GenerateValue(IEnumerable<(ConstraintTypes type, dynamic value)> constraints)
        {
            int maxDigits = NumberConstants.MaxDigitsInDecimal, decimalPlace = 0;
            foreach (var (type, value) in constraints)
            {
                switch (type)
                {
                    case ConstraintTypes.MaxDigits:
                        maxDigits = (int)value;
                        break;
                    case ConstraintTypes.DecimalPlace:
                        decimalPlace = (int)value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = (int)type };
                }
            }
            return _randomizer.CustomDecimal(maxDigits, decimalPlace);
        }

        public SupportedTypes FieldType { get => SupportedTypes.Decimal; }
    }
}
