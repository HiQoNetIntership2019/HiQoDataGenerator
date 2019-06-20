using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class EncodingType: BaseModel
    {
        [Required()]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
