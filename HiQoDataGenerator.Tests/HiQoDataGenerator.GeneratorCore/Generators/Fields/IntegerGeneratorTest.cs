﻿using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Fields;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;
using HiQoDataGenerator.Tests.Extensions;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class IntegerGeneratorTest : BaseValueGeneratorTest
    {
        public IntegerGeneratorTest()
        {
            ValueGenerator = new IntegerGenerator(RandomValuesGenerator);
        }

        [Theory]
        [ClassData(typeof(IntegerInputData))]
        public void Generate_MinAndMaxValue_InInterval(int min, int max)
        {
            var constraints = new List<ConstraintPrototype>()
            {
                new ConstraintPrototype(ConstraintTypes.Min, min),
                new ConstraintPrototype(ConstraintTypes.Max, max)
            };

            int result = ValueGenerator.Generate(constraints);

            Assert.InRange(result, min, max);
        }
    }
}
