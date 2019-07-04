using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class Constraint:BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<FieldTypeConstraint> SupportedTypes { get; set; }
    }
}
