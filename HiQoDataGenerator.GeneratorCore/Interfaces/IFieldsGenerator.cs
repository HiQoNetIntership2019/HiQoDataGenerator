using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IFieldsGenerator
    {
        (string, object) Generate(int fieldTypeId, IEnumerable<(int constraintId, object value)> constraints, int? datasetId = null);
    }
}
