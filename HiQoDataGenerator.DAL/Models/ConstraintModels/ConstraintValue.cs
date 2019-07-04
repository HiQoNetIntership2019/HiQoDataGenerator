using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{ 
    public class ConstraintValue : BaseModel
    {
        public string Value { get; set; }

        public int ConstraintId { get; set; }
        public Constraint Constraint { get; set; }
    }
}
