using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IFieldsGenerator
    {
        dynamic Generate(int fieldTypeId, IEnumerable<(int constraintId, dynamic value)> constraints, int? datasetId = null);
    }
}
