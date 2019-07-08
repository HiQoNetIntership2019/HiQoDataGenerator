using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using HiQoDataGenerator.GeneratorCore.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace HiQoDataGenerator.Tests.HiQoDataGenerator.GeneratorCore.Services
{
    public class DataGeneratorServiceTest
    {
        private readonly Mock<IFieldsGenerator> _fieldGeneratorMock = new Mock<IFieldsGenerator>();

        private IDataGeneratorService _dataGeneratorService;

        public DataGeneratorServiceTest()
        {
            _dataGeneratorService = new DataGeneratorService(_fieldGeneratorMock.Object);
        }

        [Fact]
        public void Generate_TrueNameOfResult()
        {
            string name = "test";
            var configurableObjectPrototype = GetConfigurablePrototype(name);

            var result = _dataGeneratorService.Generate(configurableObjectPrototype);

            Assert.Equal(name, result.Name);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(10, 10)]
        public void GenerateMany_CountReslutsTheory(int objectsCount, int resultCount)
        {
            var configurableObjectPrototype = GetConfigurablePrototype("test");

            var results = _dataGeneratorService.GenerateMany(configurableObjectPrototype, objectsCount);

            Assert.Equal(results.Count(), resultCount);
        }

        [Theory]
        [InlineData(3, 3, 9)]
        [InlineData(8, 1, 8)]
        [InlineData(1, 1, 1)]
        public void GenerateFromMany_TotalCountTheory(int countPrototype, int countInstanceEachObjects, int countGeneratedObjects)
        {
            var (prototypes, count) = GetPrototypes(countPrototype, countInstanceEachObjects);

            var result = _dataGeneratorService.GenerateFromManyPrototypes(prototypes, count);
            int countObjects = result.Sum(i => i.Count);

            Assert.Equal(countGeneratedObjects, countObjects);
        }

        [Fact]
        public void GenerateMany_NegativCount_ThrowException()
        {
            var configurablePrototype = GetConfigurablePrototype("test");

            void act() => _dataGeneratorService.GenerateMany(configurablePrototype, -2);

            Assert.Throws<NegativeCountObjectsException>(act);
        }

        private (IEnumerable<ConfigurablePrototype> prototypes, Dictionary<string, int> count) GetPrototypes(int countPrototypes, int countInstance)
        {
            var names = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            var count = new Dictionary<string, int>();

            for (int i = 0; i < countPrototypes; i++)
            {
                count[names[i]] = countInstance;
            }

            return (names.Take(countPrototypes).Select(i => new ConfigurablePrototype(i)), count);
        }

        private ConfigurablePrototype GetConfigurablePrototype(string name)
        {
            var fields = new List<FieldPrototype>()
            {
                new FieldPrototype("field 1", true, 1, null, null),
                new FieldPrototype("field 2", false, 2, 1, null)
            };

            return new ConfigurablePrototype(name, fields);
        }
    }
}
