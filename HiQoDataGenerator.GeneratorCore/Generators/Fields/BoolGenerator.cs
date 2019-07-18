using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class BoolGenerator : GeneratorBase<bool, bool>
    {
        public BoolGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }

        public override SupportedTypes FieldType => SupportedTypes.Bool;
        protected override bool GenerateValue()
        {
            return RandomValueGenerator.GenerateBool();
        }
    }
}
