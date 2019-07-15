using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IFieldsGenerator
    {
        dynamic Generate(SupportedTypes type, IEnumerable<ConstraintPrototype> constraints, int? datasetId = null);
    }
}
