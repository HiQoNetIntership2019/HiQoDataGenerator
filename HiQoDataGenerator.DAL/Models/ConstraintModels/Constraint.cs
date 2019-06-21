using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HiQoDataGenerator.DAL.Models.IntermediateModels;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{

    public class Constraint : BaseModel

    {
        [Required()]
        [StringLength(50)]
        public string Name { get; set; }
        
        [StringLength(50)]
        public string Description { get; set; }

        public ICollection<FieldTypeConstraint> SupportedTypes { get; set; }        
    }
}
