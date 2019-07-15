using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators;
using HiQoDataGenerator.GeneratorCore.Generators.Fields;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using Moq;
using System;
using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class IntegerGeneratorTest
    {
        private readonly Mock<IRandomValuesGenerator> _randomValuesGeneratorMock = new Mock<IRandomValuesGenerator>();
        private readonly IFieldValueGenerator _intGenerator;
       
        public IntegerGeneratorTest()
        {
            _intGenerator = new IntegerGenerator(_randomValuesGeneratorMock.Object);
        }

        [Theory]
        [ClassData(typeof(InputDataGenerator))]
        public void Generate_MinAndMaxValue_InInterval(int min, int max)
        {
            var random = new Random();
            var constraints = new List<ConstraintPrototype>()
            {
                new ConstraintPrototype(ConstraintTypes.Min, min),
                new ConstraintPrototype(ConstraintTypes.Max, max)
            };
            var generatedValue = random.Next(min, max);

            _randomValuesGeneratorMock.Setup(m => m.GenerateInt(min, max)).Returns(generatedValue);

            int result = _intGenerator.Generate(constraints);

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
