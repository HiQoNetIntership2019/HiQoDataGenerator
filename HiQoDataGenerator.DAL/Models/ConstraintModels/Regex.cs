using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class Regex : BaseModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
