using System;
using System.Text;
using HiQoDataGenerator.EventBus.Events;
using Newtonsoft.Json;

namespace HiQoDataGenerator.EventBus.Helpers
{
    public static class SerializationHelper
    {
        public static byte[] Serialize<T>(T @event) where T : BusEvent
        {
            var message = JsonConvert.SerializeObject(@event);
            return Encoding.UTF8.GetBytes(message);
        }

        public static object Deserialize(this byte[] byteArray, Type eventType)
        {
            var message = Encoding.UTF8.GetString(byteArray);
            var busEvent = JsonConvert.DeserializeObject(message, eventType);
            return busEvent;
        }
    }
}
