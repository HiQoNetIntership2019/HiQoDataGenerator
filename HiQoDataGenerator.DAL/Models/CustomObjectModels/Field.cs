using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.CustomObjectModels
{
    public class Field : BaseModel
    {
        public string Name { get; set; }
        public int ObjectId { get; set; }
        public int TypeId { get; set; }
        public virtual FieldType Type { get; set; }
        public virtual ConfigurableObject ConfigurableObject { get; set; }
    }
}
