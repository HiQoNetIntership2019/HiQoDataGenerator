using System.Linq;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Base
{
    public abstract class MinMaxGenerator<T, TC> : GeneratorBase<T, TC>
        where T: struct
        where TC: struct

    {
        protected MinMaxGenerator(IRandomValuesGenerator randomValuesGenerator) : base (randomValuesGenerator)
        {
            Constraints[ConstraintTypes.Min] = (TC)typeof(T).GetFields().First(item => item.Name == "MinValue").GetValue(null);
            Constraints[ConstraintTypes.Max] = (TC)typeof(T).GetFields().First(item => item.Name == "MaxValue").GetValue(null);
        }
    }
}
