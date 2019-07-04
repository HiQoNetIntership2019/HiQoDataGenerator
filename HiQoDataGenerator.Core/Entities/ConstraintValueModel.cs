using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class ConstraintValueModel : BaseModel
    {
        public string Value { get; }
        public int ConstraintId { get; }
        public virtual ConstraintModel Constraint { get; set; }

        public ConstraintValueModel(int id, string value, int constraintId, ConstraintModel constraint = null) : base(id)
        {
            Value = value;
            ConstraintId = constraintId;
            Constraint = constraint;
        }
    }
}
