using HiQoDataGenerator.GeneratorCore.Interfaces;
using System;
using System.Numerics;
using System.Collections.Generic;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using Bogus;

namespace HiQoDataGenerator.GeneratorCore.Models
{
    public class FieldsGenerator : IFieldsGenerator
    {

        private readonly Dictionary<int, Func<IEnumerable<(int id, dynamic value)> ,object>> _fieldsGenerators 
            = new Dictionary<int, Func<IEnumerable<(int id, dynamic value)>, object>>();

        private readonly Randomizer _randomizer = new Randomizer();

        public FieldsGenerator()
        {
            _fieldsGenerators[(int)SupportedTypes.Byte] = GenerateByte;
            _fieldsGenerators[(int)SupportedTypes.Int] = GenerateInt;
            _fieldsGenerators[(int)SupportedTypes.Double] = GenerateDouble;
            _fieldsGenerators[(int)SupportedTypes.Decimal] = GenerateDecimal;
            _fieldsGenerators[(int)SupportedTypes.Complex] = GenerateComplex;
            _fieldsGenerators[(int)SupportedTypes.String] = GenerateString;
            _fieldsGenerators[(int)SupportedTypes.Bool] = GenerateBool;
            _fieldsGenerators[(int)SupportedTypes.Date] = GenerateDate;
            _fieldsGenerators[(int)SupportedTypes.Time] = GenerateTime;
            _fieldsGenerators[(int)SupportedTypes.DateTime] = GenerateDateTime;
            _fieldsGenerators[(int)SupportedTypes.Enum] = GenerateEnum;
            _fieldsGenerators[(int)SupportedTypes.Guid] = GenerateGuid;
        }


        public dynamic Generate(int fieldTypeId, IEnumerable<(int constraintId, dynamic value)> constraints, int? datasetId = null)
        { 
            if (datasetId != null)
            {
                throw new NotImplementedException();
            }
            try
            {
                return _fieldsGenerators[fieldTypeId].Invoke(constraints);
            }
            catch (ConstraintNotSupportedException ex)
            {
                ex.FieldId = fieldTypeId;
                throw;
            }
        }


        private dynamic GenerateByte(IEnumerable<(int id, dynamic value)> constraints)
        {
            return _randomizer.Byte();
        }
        

        private dynamic GenerateInt(IEnumerable<(int id, dynamic value)> constraints)
        {
            int minValue = int.MinValue, maxValue = int.MaxValue;
            foreach (var (id, value) in constraints)
            {
                switch (id)
                {
                    case (int)ConstraintTypes.Min:
                        minValue = (int)value;
                        break;
                    case (int)ConstraintTypes.Max:
                        maxValue = (int)value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = id };
                }
            }
            return _randomizer.Int(minValue, maxValue);
        }


        private dynamic GenerateDouble(IEnumerable<(int id, dynamic value)> constraints)
        {
            double minValue = double.MinValue, maxValue = double.MaxValue;
            foreach (var (id, value) in constraints)
            {
                switch (id)
                {
                    case (int)ConstraintTypes.Min:
                        minValue = value;
                        break;
                    case (int)ConstraintTypes.Max:
                        maxValue = value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = id };
                }
            }
            return _randomizer.Double(minValue, maxValue);
        }


        private dynamic GenerateDecimal(IEnumerable<(int id, dynamic value)> constraints)
        {
            int maxDigits = NumberConstants.MaxDigitsInDecimal, decimalPlace = 0;
            foreach (var (id, value) in constraints)
            {
                switch (id)
                {
                    case (int)ConstraintTypes.MaxDigits:
                        maxDigits = (int)value;
                        break;
                    case (int)ConstraintTypes.DecimalPlace:
                        decimalPlace = (int)value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = id };
                }
            }
            return _randomizer.CustomDecimal(maxDigits, decimalPlace);
        }

        private dynamic GenerateComplex(IEnumerable<(int id, dynamic value)> constraints)
        {
            double minA = double.MinValue, maxA = double.MaxValue, minB = double.MinValue, maxB = double.MaxValue;

            foreach (var (id, value) in constraints)
            {
                switch (id)
                {
                    case (int)ConstraintTypes.MaxA:
                        maxA = (double)value;
                        break;
                    case (int)ConstraintTypes.MinA:
                        minA = (double)value;
                        break;
                    case (int)ConstraintTypes.MaxB:
                        maxB = (double)value;
                        break;
                    case (int)ConstraintTypes.MinB:
                        minB = (double)value;
                        break;
                    default:
                        throw new ConstraintNotSupportedException() { ConstraintId = id };
                }
            }

            return new Complex(_randomizer.Double(minA, maxA), _randomizer.Double(minB, maxB));
        }


        private dynamic GenerateString(IEnumerable<(int id, dynamic value)> constraints)
        {
            throw new NotImplementedException();
        }


        private dynamic GenerateBool(IEnumerable<(int id, dynamic value)> constraints)
        {
            return _randomizer.Bool();
        }

        private dynamic GenerateDate(IEnumerable<(int id, dynamic value)> constraints)
        { 
            throw new NotImplementedException();
        }


        private dynamic GenerateTime(IEnumerable<(int id, dynamic value)> constraints)
        {
            throw new NotImplementedException();
        }

        private dynamic GenerateDateTime(IEnumerable<(int id, dynamic value)> constraints)
        {
            throw new NotImplementedException();
        }


        private dynamic GenerateEnum(IEnumerable<(int id, dynamic value)> constraints)
        {
            throw new NotImplementedException();
        }


        private dynamic GenerateGuid(IEnumerable<(int id, dynamic value)> constraints)
        {
            throw new NotImplementedException();
        }
    }
}
