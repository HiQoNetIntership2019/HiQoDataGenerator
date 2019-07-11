using System;
using RabbitMQ.Client;

namespace HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus
{
    public interface IRabbitMqPersistentConnection : IDisposable
    {
        bool IsConnected { get; }

        bool TryConnect();

        IModel CreateModel();
    }
}
