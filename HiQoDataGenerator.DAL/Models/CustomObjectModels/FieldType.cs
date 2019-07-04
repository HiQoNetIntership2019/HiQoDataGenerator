using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using HiQoDataGenerator.DAL.Models.IntermediateModels;

namespace HiQoDataGenerator.DAL.Models.CustomObjectModels
{
    public class FieldType : BaseModel
    {
        public string Name { get; set; }
        
        public virtual ICollection<FieldTypeConstraint> SupportedConstraints { get; set; }
    }      
}
