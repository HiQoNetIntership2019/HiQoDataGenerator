namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetValueModel : BaseModel
    {
        public string Value { get; }
        public int DatasetId { get; }

        public CustomDatasetValueModel(int id, string value, CustomDatasetModel dataset) : base(id)
        {
            Value = value;
            DatasetId = dataset.Id;
        }

        public CustomDatasetValueModel(int id, string value, int datasetId) : base(id)
        {
            Value = value;
            DatasetId = datasetId;
        }
    }
}
