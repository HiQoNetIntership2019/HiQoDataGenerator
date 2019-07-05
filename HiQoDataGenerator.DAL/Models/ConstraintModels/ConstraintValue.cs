using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class ConstraintValue : BaseModel
    {
        public string Value { get; set; }
        public virtual Constraint Constraint { get; set; }
        public virtual Field Field { get; set; }
    }
}
