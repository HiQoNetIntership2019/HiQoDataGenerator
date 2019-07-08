using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Fields;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class IntegerGeneratorTest
    {
        private readonly IFieldValueGenerator _intGenerator = new IntegerGenerator();

        [Theory]
        [ClassData(typeof(InputDataGenerator))]
        public void Generate_MinAndMaxValue_InInterval(int min, int max)
        {
            var constraints = new List<(ConstraintTypes, dynamic)>()
            {
                (ConstraintTypes.Min, min),
                (ConstraintTypes.Max, max)
            };

            int result = _intGenerator.GenerateValue(constraints);

            Assert.InRange(result, min, max);
        }


        private class InputDataGenerator : IEnumerable<object[]>
        {
            private readonly int _countData = 10;
            private readonly Random _random = new Random();
            public IEnumerator<object[]> GetEnumerator()
            {
                for (int i = 0; i < _countData; i++)
                {
                    int begin = _random.Next(int.MinValue, int.MaxValue);
                    int end = _random.Next(begin, int.MaxValue);
                    yield return new object[] { begin, end };
                }
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
