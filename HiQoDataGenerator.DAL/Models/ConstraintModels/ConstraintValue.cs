using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;

namespace HiQoDataGenerator.DAL.Models.ConstraintModels
{
    public class ConstraintValue
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string Value { get; set; }
       
        //public int ConstraintId { get; set; }//FK
        //public Constraint Constraint { get; set; }//Navigation property        
    }
}
