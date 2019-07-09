using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.GeneratorCore.Exceptions
{
    public class ConstraintNotSupportedException : Exception
    {
        public int FieldId { get; set; }
        public int ConstraintId { get; set; }

        public override string Message => $"Field with id {FieldId} does not support constraint with id {ConstraintId}";

    }
}
