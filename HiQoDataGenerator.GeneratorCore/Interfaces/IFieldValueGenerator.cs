using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Interfaces
{
    public interface IFieldValueGenerator
    {
        SupportedTypes GetFieldType();
        dynamic GenerateValue(IEnumerable<(ConstraintTypes, dynamic)> constraints);
    }
}
