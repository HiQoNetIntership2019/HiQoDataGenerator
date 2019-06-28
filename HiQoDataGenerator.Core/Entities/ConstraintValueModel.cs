using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class ConstraintValueModel : BaseModel
    {
        public string Value { get; }
        public int ConstraintId { get; }

        public ConstraintValueModel(int id, string value, int constraintId) : base(id)
        {
            Value = value;
            ConstraintId = constraintId;
        }
    }
}
