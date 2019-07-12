using System;
using System.Collections.Generic;
using HiQoDataGenerator.EventBus.Events;
using HiQoDataGenerator.EventBus.Handlers;

namespace HiQoDataGenerator.EventBus.Interfaces
{
    public interface IEventBusSubscriptionsManager
    {
        bool IsEmpty { get; }
        event EventHandler<string> OnEventRemoved;

        void AddSubscription<T, TH>()
            where T : BusEvent
            where TH : IBusEventHandler<T>;

        void RemoveSubscription<T, TH>()
            where TH : IBusEventHandler<T>
            where T : BusEvent;
        
        bool HasHandlerTypesForEvent<T>() where T : BusEvent;
        bool HasHandlerTypesForEvent(string eventName);
        Type GetEventTypeByName(string eventName);
        void Clear();
        IEnumerable<Type> GetHandlerTypesForEvent<T>() where T : BusEvent;
        IEnumerable<Type> GetHandlerTypesForEvent(string eventName);
        IEnumerable<object> GetHandlersForEvent(string eventName);
        string GetEventKey<T>();
    }
}
