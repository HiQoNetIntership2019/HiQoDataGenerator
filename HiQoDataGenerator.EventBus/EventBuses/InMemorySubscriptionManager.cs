using System;
using System.Collections.Generic;
using System.Linq;
using HiQoDataGenerator.EventBus.Events;
using HiQoDataGenerator.EventBus.Handlers;
using HiQoDataGenerator.EventBus.Interfaces;

namespace HiQoDataGenerator.EventBus.EventBuses
{
    public class InMemorySubscriptionsManager : IEventBusSubscriptionsManager
    {
        private readonly Dictionary<string, List<Type>> _handlerTypes;
        private readonly Dictionary<string, List<object>> _handlers;

        private readonly List<Type> _eventTypes;

        public event EventHandler<string> OnEventRemoved;

        public InMemorySubscriptionsManager()
        {
            _handlerTypes = new Dictionary<string, List<Type>>();
            _handlers = new Dictionary<string, List<object>>();
            _eventTypes = new List<Type>();
        }

        public bool IsEmpty => !_handlerTypes.Keys.Any();
        public void Clear() => _handlerTypes.Clear();


        public void AddSubscription<T, TH>()
            where T : BusEvent
            where TH : IBusEventHandler<T>
        {
            var eventName = GetEventKey<T>();

            AddHandlerTypeForEvent(typeof(TH), eventName);

            if (!_eventTypes.Contains(typeof(T)))
            {
                _eventTypes.Add(typeof(T));
            }
        }

        private void AddHandlerTypeForEvent(Type handlerType, string eventName)
        {
            if (!HasHandlerTypesForEvent(eventName))
            {
                _handlerTypes.Add(eventName, new List<Type>());
                _handlers.Add(eventName, new List<object>());
            }

            if (_handlerTypes[eventName].Any(s => s == handlerType))
            {
                throw new ArgumentException(
                    $"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
            }
            _handlerTypes[eventName].Add(handlerType);
            _handlers[eventName].Add(Activator.CreateInstance(handlerType));
        }


        public void RemoveSubscription<T, TH>()
            where TH : IBusEventHandler<T>
            where T : BusEvent
        {
            var handlerToRemove = FindHandlerTypeToRemove<T, TH>();
            var eventName = GetEventKey<T>();
            DoRemoveHandler(eventName, handlerToRemove);
        }


        private void DoRemoveHandler(string eventName, Type handlerTypeToRemove)
        {
            if (handlerTypeToRemove != null)
            {
                _handlerTypes[eventName].Remove(handlerTypeToRemove);
                _handlers[eventName].RemoveAll(el => el.GetType() == handlerTypeToRemove);

                if (!_handlerTypes[eventName].Any())
                {
                    _handlerTypes.Remove(eventName);
                    var eventType = _eventTypes.SingleOrDefault(e => e.Name == eventName);
                    if (eventType != null)
                    {
                        _eventTypes.Remove(eventType);
                    }
                    RaiseOnEventRemoved(eventName);
                }
            }
        }

        public IEnumerable<Type> GetHandlerTypesForEvent<T>() where T : BusEvent
        {
            var key = GetEventKey<T>();
            return GetHandlerTypesForEvent(key);
        }

        public IEnumerable<Type> GetHandlerTypesForEvent(string eventName) => _handlerTypes[eventName];

        public IEnumerable<object> GetHandlersForEvent(string eventName) => _handlers[eventName];

        private void RaiseOnEventRemoved(string eventName)
        {
            var handler = OnEventRemoved;
            if (handler != null)
            {
                OnEventRemoved(this, eventName);
            }
        }

        private Type FindHandlerTypeToRemove<T, TH>()
             where T : BusEvent
             where TH : IBusEventHandler<T>
        {
            var eventName = GetEventKey<T>();
            return FindHandlerTypeByEventName(eventName, typeof(TH));
        }

        private Type FindHandlerTypeByEventName(string eventName, Type handlerType)
        {
            if (!HasHandlerTypesForEvent(eventName))
            {
                return null;
            }
            return _handlerTypes[eventName].SingleOrDefault(type => type == handlerType);
        }

        public bool HasHandlerTypesForEvent<T>() where T : BusEvent
        {
            var key = GetEventKey<T>();
            return HasHandlerTypesForEvent(key);
        }

        public bool HasHandlerTypesForEvent(string eventName) => _handlerTypes.ContainsKey(eventName);

        public Type GetEventTypeByName(string eventName) => _eventTypes.SingleOrDefault(t => t.Name == eventName);

        public string GetEventKey<T>()
        {
            return typeof(T).Name;
        }
    }
}
