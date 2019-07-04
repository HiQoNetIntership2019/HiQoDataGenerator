namespace HiQoDataGenerator.Core.Entities
{
    public class DefinedDatasetValueModel : BaseModel
    {
        public string Value { get; }
        public int DatasetId { get; }

        public DefinedDatasetValueModel(int id, string value, int datasetId) : base(id)
        {
            Value = value;
            DatasetId = datasetId;
        }
    }
}
