using System;
using System.Numerics;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IRandomValuesGenerator
    {
        bool GenerateBool();
        byte GenerateByte(byte min = 0, byte max = 255);
        Complex GenerateComplex(double minA, double maxA, double minB, double maxB);
        DateTime GenerateDateTime(DateTime dateStart, DateTime dateEnd);
        decimal GenerateDecimal(int maxDigits, int decimalPlace);
        double GenerateDouble(double min = double.MinValue, double max = double.MaxValue);
        int GenerateInt(int min = int.MinValue, int max = int.MaxValue);
        string GenerateString(int minLength, int maxLength);
        string GenerateString(string pattern);
    }
}