using System;
using System.Threading.Tasks;
using HiQoDataGenerator.EventBus.Events;
using HiQoDataGenerator.EventBus.Handlers;
using HiQoDataGenerator.EventBus.Interfaces;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus
{
    public class RabbitMqEventBus : IEventBus, IDisposable
    {
        private readonly IRabbitMqPersistentConnection _persistentConnection;

        private IModel _consumerChannel;
        private string _queueName;
        private readonly IEventBusSubscriptionsManager _subsManager;
        private bool IsConnected => _persistentConnection?.IsConnected ?? false;

        public RabbitMqEventBus(string queueName)
        {
            _subsManager = new InMemorySubscriptionsManager();
            _persistentConnection = new DefaultRabbitMqPersistentConnection();
            _queueName = queueName ?? "";
            _consumerChannel = CreateConsumerChannel();
            _subsManager.OnEventRemoved += SubsManager_OnEventRemoved;
        }

        public bool Publish(BusEvent @event)
        {
            if ((!IsConnected) && !_persistentConnection.TryConnect())
                return false;

            using (var channel = _persistentConnection.CreateModel())
            {
                var eventName = @event.GetType().Name;

                channel.ExchangeDeclare(ConnectionParams.ExchangeName, "direct");

                var messageBody = Helpers.SerializationHelper.Serialize(@event);

                var properties = channel.CreateBasicProperties();
                properties.DeliveryMode = 1;

                channel.BasicPublish(ConnectionParams.ExchangeName,
                    eventName,
                    true,
                    properties,
                    messageBody
                );
            }

            return true;
        }

        public bool Subscribe<T, TH>()
            where T : BusEvent
            where TH : IBusEventHandler<T>
        {
            var eventName = _subsManager.GetEventKey<T>();

            if (!DoInternalSubscription(eventName))
                return false;

            _subsManager.AddSubscription<T, TH>();
            return true;
        }

        private bool DoInternalSubscription(string eventName)
        {
            var containsKey = _subsManager.HasHandlerTypesForEvent(eventName);
            if (!containsKey)
            {
                if ((!IsConnected) && !_persistentConnection.TryConnect())
                    return false;

                using (var channel = _persistentConnection.CreateModel())
                {
                    channel.QueueBind(queue: _queueName,
                        exchange: ConnectionParams.ExchangeName,
                        routingKey: eventName);
                }
            }

            return true;
        }

        public void Unsubscribe<T, TH>()
            where T : BusEvent
            where TH : IBusEventHandler<T>
        {
            _subsManager.RemoveSubscription<T, TH>();
        }

        private IModel CreateConsumerChannel()
        {
            if (!IsConnected)
            {
                _persistentConnection.TryConnect();
            }

            var channel = _persistentConnection.CreateModel();

            channel.ExchangeDeclare(ConnectionParams.ExchangeName, "direct");

            channel.QueueDeclare(_queueName,
                                true,
                                false,
                                false,
                                null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += async (model, eventArgs) =>
            {
                var eventName = eventArgs.RoutingKey;

                await ProcessEvent(eventName, eventArgs.Body);

                channel.BasicAck(eventArgs.DeliveryTag, multiple: false);
            };

            channel.BasicConsume(_queueName, false, consumer);

            channel.CallbackException += (sender, eventArgs) =>
            {
                _consumerChannel.Dispose();
                _consumerChannel = CreateConsumerChannel();
            };

            return channel;
        }

        private async Task ProcessEvent(string eventName, byte[] message)
        {
            if (_subsManager.HasHandlerTypesForEvent(eventName))
            {
                var handlers = _subsManager.GetHandlersForEvent(eventName);
                foreach (var handler in handlers)
                {
                    var eventType = _subsManager.GetEventTypeByName(eventName);
                    var busEvent = Helpers.SerializationHelper.Deserialize(message, eventType);
                    var concreteType = typeof(IBusEventHandler<>).MakeGenericType(eventType);
                    await (Task)concreteType.GetMethod("Handle").Invoke(handler, new[] { busEvent });
                }
            }
        }

        public void Dispose()
        {
            _consumerChannel?.Dispose();

            _subsManager.Clear();
        }

        private void SubsManager_OnEventRemoved(object sender, string eventName)
        {
            if (!IsConnected && !_persistentConnection.TryConnect()) return;

            using (var channel = _persistentConnection.CreateModel())
            {
                channel.QueueUnbind(queue: _queueName,
                    exchange: ConnectionParams.ExchangeName,
                    routingKey: eventName);

                if (_subsManager.IsEmpty)
                {
                    _queueName = string.Empty;
                    _consumerChannel.Close();
                }
            }
        }
    }
}
