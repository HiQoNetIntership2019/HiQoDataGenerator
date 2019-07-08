using Bogus;
using System;

namespace HiQoDataGenerator.GeneratorCore.Extensions
{
    public static class RandomExtensions
    {
        public static Decimal CustomDecimal(this Randomizer randomizer, int maxDigits, int decimalPlace)
        {
            if (decimalPlace > maxDigits)
            {
                throw new ArgumentException();
            }
            

            ulong minIntPart = (ulong) Math.Pow(10, maxDigits - decimalPlace - 1);
            ulong maxIntPart = (ulong) Math.Pow(10, maxDigits - decimalPlace) - 1;
            ulong minDecimalPart = (ulong) Math.Pow(10, decimalPlace - 1);
            ulong maxDecimalPart = (ulong) Math.Pow(10, decimalPlace) - 1;
            

            var intPart = randomizer.ULong(minIntPart, maxIntPart);
            var decimalPart = randomizer.ULong(minDecimalPart, maxDecimalPart);

            return decimal.Parse($"{intPart},{decimalPart}");
        }
    }
}
