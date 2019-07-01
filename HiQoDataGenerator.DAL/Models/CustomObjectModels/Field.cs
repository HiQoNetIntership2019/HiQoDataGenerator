using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.CustomObjectModels
{
    public class Field : BaseModel
    {
        public string Name { get; set; }
        public bool IsRequired { get; set; }
        public virtual FieldType FieldType { get; set; }
        public virtual ConfigurableObject ConfigurableObject { get; set; }
    }
}
