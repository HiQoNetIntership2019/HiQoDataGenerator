using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HiQoDataGenerator.DAL.Models.DataSetModels
{
    public class CustomDataset : BaseModel
    {
        [Required()]
        [StringLength(50)]
        public string Name { get; set; }        
    }
}
