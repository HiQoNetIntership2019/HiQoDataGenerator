using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class Regex : BaseModel
    {
        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Value { get; set; }
    }
}
