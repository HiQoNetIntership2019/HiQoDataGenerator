using System.Collections.Generic;
using System.Linq;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Objects;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;

namespace HiQoDataGenerator.GeneratorCore.Services
{
    public class DataGeneratorService : IDataGeneratorService
    {
        private readonly IFieldsGenerator _fieldsGenerator;

        public DataGeneratorService(IFieldsGenerator fieldsGenerator)
        {
            _fieldsGenerator = fieldsGenerator;
        }


        public GeneratedObject Generate(ConfigurablePrototype prototype)
        {
            var generatedObject = new GeneratedObject(prototype.Name);

            foreach (var fieldPrototype in prototype.Fields)
            {
                var constraints = fieldPrototype.Constraints.Select(i => (i.TypeId, i.Value));
                var fieldValue = _fieldsGenerator.Generate(fieldPrototype.FieldTypeId, constraints, fieldPrototype.DatsetId);
                generatedObject.Fields.Add(new GeneratedField(fieldPrototype.Name, fieldValue));
            }

            return generatedObject;
        }


        public GeneratedObjectsCollection GenerateFromManyPrototypes(IEnumerable<ConfigurablePrototype> prototypes, Dictionary<string, int> count)
        {
            var generatedObjectsCollection = new GeneratedObjectsCollection();

            foreach (var prototype in prototypes)
            {
                generatedObjectsCollection.AddRange(GenerateMany(prototype, count[prototype.Name]));
            }

            return generatedObjectsCollection;
        }

        public IEnumerable<GeneratedObject> GenerateMany(ConfigurablePrototype prototype, int count)
        {
            if (count < 0)
            {
                throw new NegativeCountObjectsException();
            } 

            var generatedObjectsCollection = new List<GeneratedObject>();

            for (;count > 0; count--)
            {
                generatedObjectsCollection.Add(Generate(prototype));
            }

            return generatedObjectsCollection;
        }
    }
}
