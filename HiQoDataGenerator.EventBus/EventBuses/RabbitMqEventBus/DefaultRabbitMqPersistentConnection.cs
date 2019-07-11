using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;

namespace HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus
{
    public class DefaultRabbitMqPersistentConnection : IRabbitMqPersistentConnection
    {
        private readonly IConnectionFactory _connectionFactory;
        private IConnection _connection;
        private bool _disposed;

        private readonly object _syncRoot = new object();

        public DefaultRabbitMqPersistentConnection(IConnectionFactory connectionFactory = null)
        {
            _connectionFactory = connectionFactory ?? 
                                 new ConnectionFactory()
                                 {
                                     HostName = ConnectionParams.HostName,
                                     UserName = ConnectionParams.Username,
                                     Password = ConnectionParams.Password
                                 };
        }

        public bool IsConnected => _connection != null && _connection.IsOpen && !_disposed;

        public IModel CreateModel()
        {
            return _connection.CreateModel();
        }

        public void Dispose()
        {
            if (_disposed) return;
            _disposed = true;
            _connection.Dispose();
        }

        public bool TryConnect()
        {
            lock (_syncRoot)
            {
                try
                {
                    _connection = _connectionFactory.CreateConnection();
                }
                catch (BrokerUnreachableException)
                {
                    return false;
                }

                if (IsConnected)
                {
                    _connection.ConnectionShutdown += OnConnectionShutdown;
                    _connection.CallbackException += OnCallbackException;
                    _connection.ConnectionBlocked += OnConnectionBlocked;
                    return true;
                }

                return false;
            }
        }

        private void OnConnectionBlocked(object sender, ConnectionBlockedEventArgs e)
        {
            if (_disposed) return;
            TryConnect();
        }

        private void OnCallbackException(object sender, CallbackExceptionEventArgs e)
        {
            if (_disposed) return;
            TryConnect();
        }

        private void OnConnectionShutdown(object sender, ShutdownEventArgs reason)
        {
            if (_disposed) return;
            TryConnect();
        }
    }
}
