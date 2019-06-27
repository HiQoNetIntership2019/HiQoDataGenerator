namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetModel : BaseModel
    {
        public string Value { get; }

        public CustomDatasetModel(int id, string value) : base(id)
        {
            Value = value;
        }
    }
}
