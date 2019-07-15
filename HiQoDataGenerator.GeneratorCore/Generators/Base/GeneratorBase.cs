using Bogus;
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
        protected readonly IRandomValuesGenerator _randomValueGenerator;
        protected readonly Dictionary<ConstraintTypes, TC> _constraints = new Dictionary<ConstraintTypes, TC>();

        public abstract SupportedTypes FieldType { get; }

        public GeneratorBase(IRandomValuesGenerator randomValuesGenerator)
        {
            _randomValueGenerator = randomValuesGenerator;
        }

        protected void LoadConstraints(IEnumerable<ConstraintPrototype> constraints)
        {
            foreach (var constraint in constraints)
            {
                if (!_constraints.ContainsKey(constraint.Type))
                {
                    throw new ConstraintNotSupportedException() { ConstraintId = (int)constraint.Type };
                }
                _constraints[constraint.Type] = (TC) constraint.Value;
            }
        }

        public abstract T Generate(IEnumerable<ConstraintPrototype> constraints);

        dynamic IFieldValueGenerator.Generate(IEnumerable<ConstraintPrototype> constraints)
        {
            return Generate(constraints);
        }
    }
}
