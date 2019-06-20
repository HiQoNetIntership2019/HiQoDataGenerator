using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class Regex
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Value { get; set; }
    }
}
