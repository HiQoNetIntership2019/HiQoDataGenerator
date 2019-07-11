namespace HiQoDataGenerator.EventBus.Events
{
    public class BusEvent
    {
        public string Description { get; set; }

        public BusEvent(string description)
        {
            Description = description;
        }
    }
}
