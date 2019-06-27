namespace HiQoDataGenerator.Core.Entities
{
    public class CustomDatasetValueModel : BaseModel
    {
        public string Value { get; }

        public CustomDatasetValueModel(int id, string value) : base(id)
        {
            Value = value;
        }
    }
}
