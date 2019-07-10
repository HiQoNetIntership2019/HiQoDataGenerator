using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    class DateGenerator : DateTimeGenerator, IFieldValueGenerator
    {
        public override SupportedTypes FieldType => SupportedTypes.Date;

        public override dynamic GenerateValue(IEnumerable<(ConstraintTypes type, dynamic value)> constraints)
        {
            return base.GenerateValue(constraints).ToShortDateString();
        }
    }
}
