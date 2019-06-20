using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.CustomObjectModels
{
    public class Field : BaseModel
    {
        [StringLength(250)]
        public string Name { get; set; }

        public virtual FieldType Type { get; set; }
    }
}
