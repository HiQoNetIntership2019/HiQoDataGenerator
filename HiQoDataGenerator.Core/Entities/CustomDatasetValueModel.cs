namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetValueModel : BaseModel
    {
        public string Value { get; }

        public CustomDatasetModel Dataset;

        public CustomDatasetValueModel(int id, string value, CustomDatasetModel dataset) : base(id)
        {
            Value = value;
            Dataset = dataset;
        }
    }
}
