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

        private IEnumerable<ConstraintPrototype> LoadConstraints(IEnumerable<ConstraintPrototype> constraints)
        {
            var defaultConstraints = new List<ConstraintPrototype>();

            foreach (var constraint in constraints)
            {
                if (!Constraints.ContainsKey(constraint.Type))
                {
                    throw new ConstraintNotSupportedException() { ConstraintId = (int)constraint.Type };
                }
                defaultConstraints.Add(new ConstraintPrototype(constraint.Type, Constraints[constraint.Type]));
                Constraints[constraint.Type] = (TC) constraint.Value;
            }

            return defaultConstraints;
        }

        protected abstract T GenerateValue();

        public T Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            var oldConstraints = LoadConstraints(constraints);
            var value = GenerateValue();
            SetDefaultConstraints(oldConstraints);
            return value;

        }

        dynamic IFieldValueGenerator.Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            return Generate(constraints);
        }

        private void SetDefaultConstraints(IEnumerable<ConstraintPrototype> defaultConstraints)
        {
            foreach (var constraint in defaultConstraints)
            {
                Constraints[constraint.Type] = (TC) constraint.Value;
            }
        } 
    }
}
