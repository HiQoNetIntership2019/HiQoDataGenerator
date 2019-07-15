using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Generators.Base;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Fields
{
    public class ByteGenerator : GeneratorBase<byte, byte>
    {
        public ByteGenerator(IRandomValuesGenerator randomValuesGenerator) : base(randomValuesGenerator) { }

        public override SupportedTypes FieldType => SupportedTypes.Byte;

        public override byte Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            LoadConstraints(constraints);
            return _randomValueGenerator.GenerateByte(_constraints[ConstraintTypes.Min], _constraints[ConstraintTypes.Max]);
        }
    }
}
