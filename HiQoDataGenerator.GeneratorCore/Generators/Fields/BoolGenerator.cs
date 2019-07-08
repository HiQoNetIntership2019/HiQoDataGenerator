using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class BoolGenerator : GeneratorBase, IFieldValueGenerator
    {
        public dynamic GenerateValue(IEnumerable<(ConstraintTypes, dynamic)> constraints)
        {
            return _randomizer.Bool();
        }

        public SupportedTypes GetFieldType()
        {
            return SupportedTypes.Bool;
        }
    }
}
