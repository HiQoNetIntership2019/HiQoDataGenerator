using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Models.IntermediateModels
{
    public class FieldTypeConstraint : BaseModel
    {
        public int FieldTypeId { get; set; }
        public virtual FieldType FieldType { get; set; }
        public int ConstraintId { get; set; }
        public virtual Constraint Constraint { get; set; }
    }
}
