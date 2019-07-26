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
            Constraints[ConstraintTypes.StartDate] = null;
            Constraints[ConstraintTypes.EndDate] = null;
            Constraints[ConstraintTypes.TimeZone] = null;
        }

        protected override DateTime GenerateValue()
        {
            var dateBegin = Constraints[ConstraintTypes.StartDate] != null
                ? DateTime.Parse(Constraints[ConstraintTypes.StartDate])
                : DateTime.MinValue;

            var dateEnd = Constraints[ConstraintTypes.EndDate] != null
                ? DateTime.Parse(Constraints[ConstraintTypes.EndDate])
                : DateTime.MaxValue;

            return RandomValueGenerator.GenerateDateTime(dateBegin, dateEnd);
        }
    }
}
