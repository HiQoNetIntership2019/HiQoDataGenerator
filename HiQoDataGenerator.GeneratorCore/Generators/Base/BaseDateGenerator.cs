using System;
using System.Collections.Generic;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;

namespace HiQoDataGenerator.GeneratorCore.Generators.Base
{
    public abstract class BaseDateGenerator : GeneratorBase<DateTime, dynamic>
    {
        protected BaseDateGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        { 
            Constraints[ConstraintTypes.StartDate] = DateTime.MinValue;
            Constraints[ConstraintTypes.EndDate] = DateTime.MaxValue;
            Constraints[ConstraintTypes.TimeZone] = null;
        }

        protected override DateTime GenerateValue()
        {
            var dateBegin = DateTime.Parse(Constraints[ConstraintTypes.StartDate]);
            var dateEnd = DateTime.Parse(Constraints[ConstraintTypes.EndDate]);
            return RandomValueGenerator.GenerateDateTime(dateBegin, dateEnd);
        }
    }
}
