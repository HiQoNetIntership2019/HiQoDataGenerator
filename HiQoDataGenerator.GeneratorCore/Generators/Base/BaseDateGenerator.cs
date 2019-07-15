using System;
using System.Collections.Generic;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;

namespace HiQoDataGenerator.GeneratorCore.Generators.Base
{
    public abstract class BaseDateGenerator : GeneratorBase<DateTime, dynamic>
    {
        public BaseDateGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        { 
            _constraints[ConstraintTypes.StartDate] = DateTime.MinValue;
            _constraints[ConstraintTypes.EndDate] = DateTime.MaxValue;
            _constraints[ConstraintTypes.TimeZone] = null;
        }

        public override DateTime Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            LoadConstraints(constraints);
            var dateBegin = DateTime.Parse(_constraints[ConstraintTypes.StartDate]);
            var dateEnd = DateTime.Parse(_constraints[ConstraintTypes.EndDate]);
            return _randomValueGenerator.GenerateDateTime(dateBegin, dateEnd);
        }
    }
}
