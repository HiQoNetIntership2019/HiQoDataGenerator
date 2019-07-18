using System;
using Fare;
using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class GuidGenerator : GeneratorBase<string, string>
    {
        public GuidGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator)
        {
            Constraints[ConstraintTypes.Regex] = null;
        }

        public override SupportedTypes FieldType => SupportedTypes.Guid;
        protected override string GenerateValue()
        {
            return Constraints[ConstraintTypes.Regex] != null
                ? new Xeger(Constraints[ConstraintTypes.Regex]).Generate()
                : Guid.NewGuid().ToString();
        }
    }
}