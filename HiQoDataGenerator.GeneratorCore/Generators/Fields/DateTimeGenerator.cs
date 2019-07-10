using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using System;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class DateTimeGenerator : GeneratorBase, IFieldValueGenerator
    {
        public virtual SupportedTypes FieldType { get => SupportedTypes.DateTime; }

        public virtual dynamic GenerateValue(IEnumerable<(ConstraintTypes type, dynamic value)> constraints)
        {
            DateTime begin = DateTime.MinValue, end = DateTime.MaxValue;
            foreach(var (type, value) in constraints)
            {
                switch (type)
                {
                    case ConstraintTypes.StartDate:
                        begin = DateTime.Parse(value);
                        break;
                    case ConstraintTypes.EndDate:
                        end = DateTime.Parse(value);
                        break;

                }
            }
            return _faker.Date.Between(begin, end);
        }
    }
}
