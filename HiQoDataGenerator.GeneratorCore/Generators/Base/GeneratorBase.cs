using HiQoDataGenerator.DAL.Restrictions;
using HiQoDataGenerator.GeneratorCore.Exceptions;
using HiQoDataGenerator.GeneratorCore.Extensions;
using HiQoDataGenerator.GeneratorCore.Interfaces;
using HiQoDataGenerator.GeneratorCore.Models.Prototypes;
using System.Collections.Generic;

namespace HiQoDataGenerator.GeneratorCore.Generators.Base 
{
    public abstract class GeneratorBase<T, TC> : IFieldValueGenerator
    {
        protected readonly IRandomValuesGenerator RandomValueGenerator;
        protected readonly Dictionary<ConstraintTypes, TC> Constraints = new Dictionary<ConstraintTypes, TC>();

        public abstract SupportedTypes FieldType { get; }

        protected GeneratorBase(IRandomValuesGenerator randomValuesGenerator)
        {
            RandomValueGenerator = randomValuesGenerator;
        }

        protected void LoadConstraints(IEnumerable<ConstraintPrototype> constraints)
        {
            foreach (var constraint in constraints)
            {
                if (!Constraints.ContainsKey(constraint.Type))
                {
                    throw new ConstraintNotSupportedException() { ConstraintId = (int)constraint.Type };
                }
                Constraints[constraint.Type] = (TC) constraint.Value;
            }
        }

        protected abstract T GenerateValue();

        public T Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            LoadConstraints(constraints);
            return GenerateValue();
        }

        dynamic IFieldValueGenerator.Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            return Generate(constraints);
        }
    }
}
