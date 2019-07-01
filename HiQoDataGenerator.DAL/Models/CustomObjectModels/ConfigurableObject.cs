using System;
using System.Collections.Generic;

namespace HiQoDataGenerator.DAL.Models.CustomObjectModels
{
    public class ConfigurableObject : BaseModel
    {
        public string Name { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateChange { get; set; }

        public ICollection<Field> Fields { get; set; }
    }
}
