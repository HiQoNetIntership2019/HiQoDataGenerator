using System;
using System.Collections.Generic;
using System.Linq;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Base
{
    public abstract class MinMaxGenerator<T, TC> : GeneratorBase<T, TC>
        where T: struct
        where TC: struct

    {
        public MinMaxGenerator(IRandomValuesGenerator randomValuesGenerator) : base (randomValuesGenerator)
        {
            _constraints[ConstraintTypes.Min] = (TC)typeof(T).GetFields().First(item => item.Name == "MinValue").GetValue(null);
            _constraints[ConstraintTypes.Max] = (TC)typeof(T).GetFields().First(item => item.Name == "MaxValue").GetValue(null);
        }
    }
}
