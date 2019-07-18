using System.Collections.Generic;
using System.Numerics;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Fields;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using HiQoDataGenerator.Tests.Extensions;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class ComplexGeneratorTest : BaseValueGeneratorTest
    {
        public ComplexGeneratorTest()
        {
            ValueGenerator = new ComplexGenerator(RandomValuesGenerator);
        }

        [Theory]
        [ClassData(typeof(ComplexInputData))]
        public void Generate_MinAndMaxValueA_InInterval(double minA, double maxA, double minB, double maxB)
        { 
            var constraints = new List<ConstraintPrototype>()
            {
                new ConstraintPrototype(ConstraintTypes.MinA, minA),
                new ConstraintPrototype(ConstraintTypes.MaxA, maxA),
                new ConstraintPrototype(ConstraintTypes.MinB, minB),
                new ConstraintPrototype(ConstraintTypes.MaxB, maxB),
            };
            
            Complex result = ValueGenerator.Generate(constraints);

            Assert.InRange(result.Real, minA, maxA);
        }

        [Theory]
        [ClassData(typeof(ComplexInputData))]
        public void Generate_MinAndMaxValueB_InInterval(double minA, double maxA, double minB, double maxB)
        {
            var constraints = new List<ConstraintPrototype>()
            {
                new ConstraintPrototype(ConstraintTypes.MinA, minA),
                new ConstraintPrototype(ConstraintTypes.MaxA, maxA),
                new ConstraintPrototype(ConstraintTypes.MinB, minB),
                new ConstraintPrototype(ConstraintTypes.MaxB, maxB),
            };

            Complex result = ValueGenerator.Generate(constraints);

            Assert.InRange(result.Imaginary, minB, maxB);
        }
    }
}
