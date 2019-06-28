using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{ 
    public class ConstraintValue : BaseModel
    {
        [Required()]
        [StringLength(300)]
        public string Value { get; set; }

        public virtual Constraint Constraint { get; set; }
    }
}
