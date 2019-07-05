using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Entities
{
    public class ConstraintValueModel : BaseModel
    {
        public string Value { get; }
        public ConstraintModel ConstraintType { get; }

        public ConstraintValueModel(int id, string value, ConstraintModel constraintType) : base(id)
        {
            Value = value;
            ConstraintType = constraintType;
        }
    }
}
