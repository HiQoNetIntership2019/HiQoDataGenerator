namespace HiQoDataGenerator.DAL.Models.DataSetModels
{
    public class DefinedDatasetValue : BaseModel
    {
        public string Value { get; set; }
        public int DatasetId { get; set; }
        public virtual DefinedDataset Dataset { get; set; }
    }
}
