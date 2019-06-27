using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.DataSetModels
{
    public class CustomDataset : BaseModel
    {
        [Required()]
        [StringLength(50)]
        public string Name { get; set; }

        public List<CustomDatasetValue> Values { get; set; }
    }
}
