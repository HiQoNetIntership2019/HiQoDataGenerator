using System.Collections.Generic;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Fields;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using HiQoDataGenerator.Tests.Extensions;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class ByteValueGenerator : BaseValueGeneratorTest
    {
        public ByteValueGenerator()
        {
            ValueGenerator = new ByteGenerator(RandomValuesGenerator);
        }

        [Theory]
        [ClassData(typeof(ByteInputData))]
        public void Generate_MinAndMaxValue_InInterval(byte min, byte max)
        {
            var constraints = new List<ConstraintPrototype>()
            {
                new ConstraintPrototype(ConstraintTypes.Min, min),
                new ConstraintPrototype(ConstraintTypes.Max, max)
            };
            double result = ValueGenerator.Generate(constraints);

            Assert.InRange(result, min, max);

        }
    }
}