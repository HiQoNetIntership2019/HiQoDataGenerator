using Bogus;
using System;
using System.Numerics;
using Fare;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators
{
    public class RandomValuesGenerator : IRandomValuesGenerator
    {
        private readonly Faker _faker = new Faker();


        public byte GenerateByte(byte min = byte.MinValue, byte max = byte.MaxValue)
        {
            return _faker.Random.Byte(min, max);
        }


        public int GenerateInt(int min = int.MinValue, int max = int.MaxValue)
        {
            return _faker.Random.Int(min, max);
        }


        public double GenerateDouble(double min = double.MinValue, double max = double.MaxValue)
        {
            return _faker.Random.Double(min, max);
        }


        public Decimal GenerateDecimal(int maxDigits, int decimalPlace)
        {
            if (decimalPlace > maxDigits)
            {
                throw new ArgumentException();
            }

            ulong minIntPart = (ulong)Math.Pow(10, maxDigits - decimalPlace - 1);
            ulong maxIntPart = (ulong)Math.Pow(10, maxDigits - decimalPlace) - 1;
            ulong minDecimalPart = (ulong)Math.Pow(10, decimalPlace - 1);
            ulong maxDecimalPart = (ulong)Math.Pow(10, decimalPlace) - 1;

            var intPart = _faker.Random.ULong(minIntPart, maxIntPart);
            var decimalPart = _faker.Random.ULong(minDecimalPart, maxDecimalPart);

            return decimal.Parse($"{intPart},{decimalPart}");
        }


        public Complex GenerateComplex(double minA, double maxA, double minB, double maxB)
        {
            return new Complex(_faker.Random.Double(minA, maxA), _faker.Random.Double(minB, maxB));
        }


        public string GenerateString(string pattern)
        {
            return new Xeger(pattern).Generate();
        }


        public string GenerateString(int minLength, int maxLength)
        {
            return _faker.Random.String2(minLength, maxLength);
        }


        public DateTime GenerateDateTime(DateTime dateStart, DateTime dateEnd)
        {
            return _faker.Date.Between(dateStart, dateEnd);
        }

        public bool GenerateBool()
        {
            return _faker.Random.Bool();
        }

    }
}
