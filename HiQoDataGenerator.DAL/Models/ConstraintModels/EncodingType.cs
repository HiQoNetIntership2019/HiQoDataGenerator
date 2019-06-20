using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class EncodingType: BaseModel
    {
        //public int Id { get; set; }

        [Required()]
        [StringLength(50)]
        public string Name { get; set; }

       /* [StringLength(50)]
        public string Value { get; set; }*/

    }
}
