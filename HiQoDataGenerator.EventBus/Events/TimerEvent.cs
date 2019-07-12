namespace HiQoDataGenerator.EventBus.Events
{
    public class TimerEvent : BusEvent
    {
        public TimerEvent(string description) : base(description) { }
    }
}
