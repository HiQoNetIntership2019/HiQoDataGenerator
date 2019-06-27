using System.ComponentModel.DataAnnotations;

namespace HiQoDataGenerator.DAL.Models.DataSetModels
{
    public class CustomDatasetValue : BaseModel
    {
        [Required()]
        [StringLength(50)]
        public string Value { get; set; }

        public int DatasetId { get; set; }
        public virtual CustomDataset Dataset { get; set; }
    }
}
