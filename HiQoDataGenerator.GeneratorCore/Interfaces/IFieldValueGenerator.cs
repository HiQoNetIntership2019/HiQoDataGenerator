using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IFieldValueGenerator
    {
        SupportedTypes FieldType { get; }
        dynamic Generate(IEnumerable<ConstraintPrototype> constraints);
    }
}
