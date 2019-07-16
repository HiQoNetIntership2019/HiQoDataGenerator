using HiQoDataGenerator.GeneratorCore.Models.Objects;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IDataGeneratorService
    {
        GeneratedObject Generate(ConfigurablePrototype prototype, ICollection<DatasetPrototype> datasetPrototypes = null);
        IEnumerable<GeneratedObject> GenerateMany(ConfigurablePrototype prototype, int count, ICollection<DatasetPrototype> datasetPrototypes = null);
        GeneratedObjectsCollection GenerateFromManyPrototypes(IEnumerable<ConfigurablePrototype> prototypes, Dictionary<string, int> count, ICollection<DatasetPrototype> datasetPrototypes = null); 
    }
}
