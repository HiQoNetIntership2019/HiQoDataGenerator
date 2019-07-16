using System;
using HiQoDataGenerator.GeneratorCore.Generators;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using Moq;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public abstract class BaseValueGeneratorTest
    {
        protected readonly IRandomValuesGenerator RandomValuesGenerator = new RandomValuesGenerator();
        protected IFieldValueGenerator ValueGenerator;
    }
}
