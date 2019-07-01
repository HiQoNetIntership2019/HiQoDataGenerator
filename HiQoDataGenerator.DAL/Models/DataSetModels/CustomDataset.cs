using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiQoDataGenerator.DAL.Models.DataSetModels
{
    public class CustomDataset : BaseModel
    {
        public string Name { get; set; }
        
        public virtual ICollection<CustomDatasetValue> Values { get; set; }
    }
}
