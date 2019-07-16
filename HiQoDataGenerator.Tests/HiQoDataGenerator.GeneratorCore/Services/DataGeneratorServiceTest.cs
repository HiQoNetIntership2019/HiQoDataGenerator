using HiQoDataGenerator.DAL.Restrictions;
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

        private readonly IDataGeneratorService _dataGeneratorService;

        public DataGeneratorServiceTest()
        {
            _dataGeneratorService = new DataGeneratorService(_fieldGeneratorMock.Object);
        }

        [Fact]
        public void Generate_TrueNameOfResult()
        {
            var name = "test";
            var configurableObjectPrototype = GetConfigurablePrototype(name);

            var result = _dataGeneratorService.Generate(configurableObjectPrototype);

            Assert.Equal(name, result.Name);
        }


        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        [InlineData(10, 10)]
        public void GenerateMany_CorrectResultsCount(int objectsCount, int resultCount)
        {
            var configurableObjectPrototype = GetConfigurablePrototype("test");

            var results = _dataGeneratorService.GenerateMany(configurableObjectPrototype, objectsCount);

            Assert.Equal(results.Count(), resultCount);
        }

        [Theory]
        [InlineData(3, 3, 9)]
        [InlineData(8, 1, 8)]
        [InlineData(1, 1, 1)]
        public void GenerateFromMany_CorrectTotalCount(int countPrototype, int countInstanceEachObjects, int countGeneratedObjects)
        {
            var (prototypes, count) = GetPrototypes(countPrototype, countInstanceEachObjects);

            var result = _dataGeneratorService.GenerateFromManyPrototypes(prototypes, count);
            var countObjects = result.Sum(i => i.Count);

            Assert.Equal(countGeneratedObjects, countObjects);
        }

        [Fact]
        public void GenerateMany_NegativeCount_ThrowException()
        {
            var configurablePrototype = GetConfigurablePrototype("test");

            Action act = () => _dataGeneratorService.GenerateMany(configurablePrototype, -2);

            Assert.Throws<NegativeCountObjectsException>(act);
        }

        [Fact]
        public void Generate_WithDatasets_CorrectValues()
        {
            var datasetPrototypes = GetDatasetPrototypes();
            var concretePrototype = datasetPrototypes.First((d => d.Id == 1));
            var configurablePrototype = GetConfigurablePrototype("testWithDatasets");
            ConfigureFieldGeneratorMock(concretePrototype, SupportedTypes.Double);

            var result = _dataGeneratorService.Generate(configurablePrototype, datasetPrototypes);

            Assert.Contains(result.Fields.First(f => f.Name == "field 2").Value, concretePrototype.Values);
        }

        private (IEnumerable<ConfigurablePrototype> prototypes, Dictionary<string, int> count) GetPrototypes(int countPrototypes, int countInstance)
        {
            var names = new[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
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
                new FieldPrototype("field 1", true, SupportedTypes.Int, null),
                new FieldPrototype("field 2", false, SupportedTypes.Double, 1)
            };

            return new ConfigurablePrototype(name, fields);
        }

        private ICollection<DatasetPrototype> GetDatasetPrototypes()
        {
            var datasetPrototypes = new List<DatasetPrototype>()
            {
                new DatasetPrototype(1, new List<dynamic>(){ "value1", "value2", "value3" }),
                new DatasetPrototype(2, new List<dynamic>(){ "value4", "value5", "value6" }),
                new DatasetPrototype(3, new List<dynamic>(){ 1, 2, 5, 4 }),
                new DatasetPrototype(4, new List<dynamic>(){ 6, 7, 8 })
            };

            return datasetPrototypes;
        }

        private void ConfigureFieldGeneratorMock(DatasetPrototype datasetPrototype, SupportedTypes supportedType)
        {
            _fieldGeneratorMock.Setup(generator =>
                generator.Generate(supportedType, new List<ConstraintPrototype>(), datasetPrototype)).Returns(GetRandomValue(datasetPrototype));
        }

        private dynamic GetRandomValue(DatasetPrototype datasetPrototype)
        {
            var random = new Random();
            var index = random.Next(0, datasetPrototype.Values.Count - 1);
            return datasetPrototype.Values.ElementAt(index);
        }
    }
}
