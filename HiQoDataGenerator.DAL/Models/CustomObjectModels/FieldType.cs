using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;

namespace HiQoDataGenerator.DAL.Models.CustomObjectModels
{
    public class FieldType
    {
        public int Id { get; set; }

        [Required()]
        [StringLength(30)]
        public string Name { get; set; }

        public virtual List<TypeConstraint> SupportedConstraints { get; set; }
    }      
}
