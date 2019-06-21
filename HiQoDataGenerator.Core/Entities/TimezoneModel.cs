namespace HiQoDataGenerator.Core.Entities
{
    public class TimezoneModel : BaseEntity
    {
        public string Value { get; }

        public TimezoneModel(string value) => Value = value;
    }
}
