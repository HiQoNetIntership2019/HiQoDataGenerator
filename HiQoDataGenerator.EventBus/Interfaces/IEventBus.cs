using HiQoDataGenerator.EventBus.Events;
using HiQoDataGenerator.EventBus.Handlers;

namespace HiQoDataGenerator.EventBus.Interfaces
{
    public interface IEventBus
    {
        bool Publish(BusEvent @event);

        bool Subscribe<T, TH>(TH handler)
            where T : BusEvent
            where TH : IBusEventHandler<T>;

        void Unsubscribe<T, TH>()
            where TH : IBusEventHandler<T>
            where T : BusEvent;
    }
}
