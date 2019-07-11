using HiQoDataGenerator.EventBus.Events;
using System.Threading.Tasks;

namespace HiQoDataGenerator.EventBus.Handlers
{
    public interface IBusEventHandler
    {

    }

    public interface IBusEventHandler<in TBusEvent> : IBusEventHandler
       where TBusEvent : BusEvent
    {
        Task Handle(TBusEvent @event);
    }
}
