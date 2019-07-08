namespace HiQoDataGenerator.Core.Entities
{
    public class DatasetValueModel : BaseModel
    {
        public string Value { get; }

        public DatasetValueModel(int id, string value) : base(id)
        {
            Value = value;
        }
    }
}
