using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IDatasetValueGenerator
    {
        dynamic Generate(ICollection<dynamic> datasetValues);
        IEnumerable<dynamic> GenerateMany(ICollection<dynamic> datasetValues);
    }
}
