using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace HiQoDataGenerator.Web.LoggingInfrastructure
{
    public class ElmahRedisClient
    {
        private IDatabase _database;
        private IConnectionMultiplexer _connectionMultiplexer;
        private readonly string _connectionString;

        public bool IsConnected { get { return _connectionMultiplexer == null ? false : _connectionMultiplexer.IsConnected; } }

        public ElmahRedisClient(string connectionString)
        {
            _connectionString = connectionString;
            TryToConnect();
        }

        private void TryToConnect()
        {
            try
            {
                _connectionMultiplexer = ConnectionMultiplexer.Connect(_connectionString);
                _database = _connectionMultiplexer.GetDatabase();
            }
            catch (RedisConnectionException)
            {
                _connectionMultiplexer = null;
                _database = null;
            }
        }

        private async Task TryToConnectAsync()
        {         
            try
            {
                _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(_connectionString);
                _database = _connectionMultiplexer.GetDatabase();
            }
            catch (RedisConnectionException)
            {
                _connectionMultiplexer = null;
                _database = null;
            }
        }

        public async void SetDataAsync(string key, ErrorData errorData)
        {
            if (!IsConnected)
                await TryToConnectAsync();
            if (IsConnected)
            {
                var value = JsonConvert.SerializeObject(errorData);
                await _database.StringSetAsync(key, value);
            }
        }

        public ErrorData GetData(string key)
        {
            ErrorData result = null;
            if (!IsConnected)
                TryToConnect();
            if (IsConnected)
            {
                var value = _database.StringGet(key);
                result = JsonConvert.DeserializeObject<ErrorData>(value);
            }
            return result;
        }

        public IEnumerable<ErrorData> GetValues(string pattern)
        {
            List<ErrorData> values = new List<ErrorData>();
            if (!IsConnected)
                TryToConnect();
            if (IsConnected)
            {
                var server = _connectionMultiplexer.GetServer(_connectionString);
                var keys = server.Keys(pattern: pattern);

                foreach (var key in keys)
                {
                    values.Add(GetData(key));
                }
            }
            return values;
        }
    }
}
