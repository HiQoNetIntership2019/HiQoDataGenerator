using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IFieldValueGenerator
    {
        SupportedTypes FieldType { get; }
        dynamic GenerateValue(IEnumerable<(ConstraintTypes type, dynamic value)> constraints);
    }
}
