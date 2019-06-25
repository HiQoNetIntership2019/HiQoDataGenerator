using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class DateTimeFormat : BaseModel
    {
        [Required()]
        [StringLength(50)]
        public string Value { get; set; }
    }
}
