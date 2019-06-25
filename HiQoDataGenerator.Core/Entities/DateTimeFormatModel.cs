namespace HiQoDataGenerator.Core.Entities
{
    public class DateTimeFormatModel : BaseModel
    {
        public string Value { get; }

        public DateTimeFormatModel(int id, string value) : base(id)
        {
            Value = value;
        }
    }
}
