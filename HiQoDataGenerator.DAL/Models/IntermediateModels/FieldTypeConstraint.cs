using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.ConstraintModels;

namespace HiQoDataGenerator.DAL.Models.IntermediateModels
{
    [Table("Types_Support_Constraints")]
    public class FieldTypeConstraint
    {
        public int Id { get; set; }

        public int FieldTypeId { get; set; }
        
        [ForeignKey("TypeId")]
        public virtual FieldType FieldType { get; set; }

        public int ConstraintId { get; set; }
        public virtual Constraint Constraint { get; set; }
    }
}
