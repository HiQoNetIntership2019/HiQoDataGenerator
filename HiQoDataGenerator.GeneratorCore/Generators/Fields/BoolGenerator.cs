using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class BoolGenerator : GeneratorBase<bool, bool>
    {
        public BoolGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }

        public override SupportedTypes FieldType => SupportedTypes.Bool;
        public override bool Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            return _randomValueGenerator.GenerateBool();
        }
    }
}
