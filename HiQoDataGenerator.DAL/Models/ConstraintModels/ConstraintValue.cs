using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class ConstraintValue : BaseModel
    {
        [StringLength(30)]
        public string Value { get; set; }

        public int ConstraintId { get; set; }
        public virtual Constraint Constraint { get; set; }
    }
}
