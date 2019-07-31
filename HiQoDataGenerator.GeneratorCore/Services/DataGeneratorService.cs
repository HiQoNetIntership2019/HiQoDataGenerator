using System;
using System.Collections.Generic;
using System.Linq;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Objects;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;

namespace HiQoDataGenerator.GeneratorCore.Services
{
    public class DataGeneratorService : IDataGeneratorService
    {
        private readonly IFieldsGenerator _fieldsGenerator;
        private readonly Random _random = new Random();

        public DataGeneratorService(IFieldsGenerator fieldsGenerator)
        {
            _fieldsGenerator = fieldsGenerator;
        }


        public GeneratedObject Generate(ConfigurablePrototype prototype, ICollection<DatasetPrototype> datasetPrototypes = null)
        {
            var generatedObject = new GeneratedObject(prototype.Name);

            foreach (var fieldPrototype in prototype.Fields)
            {
                var datasetPrototype = datasetPrototypes?.FirstOrDefault(d => d.Id == fieldPrototype.DatasetId);
                var fieldValue = !fieldPrototype.IsRequired && _random.Next(2) == 1
                    ? null
                    : _fieldsGenerator.Generate(fieldPrototype.Type, fieldPrototype.Constraints, datasetPrototype);

                generatedObject.Fields.Add(new GeneratedField(fieldPrototype.Name, fieldValue));
            }

            return generatedObject;
        }


        public GeneratedObjectsCollection GenerateFromManyPrototypes(IEnumerable<ConfigurablePrototype> prototypes, Dictionary<string, int> count, ICollection<DatasetPrototype> datasetPrototypes)
        {
            var generatedObjectsCollection = new GeneratedObjectsCollection();

            foreach (var prototype in prototypes)
            {
                generatedObjectsCollection.AddRange(GenerateMany(prototype, count[prototype.Name], datasetPrototypes));
            }

            return generatedObjectsCollection;
        }

        public IEnumerable<GeneratedObject> GenerateMany(ConfigurablePrototype prototype, int count, ICollection<DatasetPrototype> datasetPrototypes)
        {
            if (count < 0)
            {
                throw new NegativeCountObjectsException();
            } 

            var generatedObjectsCollection = new List<GeneratedObject>();

            for (int i = 0; i < count; i++)
            {
                generatedObjectsCollection.Add(Generate(prototype, datasetPrototypes));
            }

            return generatedObjectsCollection;
        }
    }
}
