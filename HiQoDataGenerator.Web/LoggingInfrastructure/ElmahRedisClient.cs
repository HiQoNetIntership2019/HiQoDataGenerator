using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.Infrastructure.LoggerExtensions;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace HiQoDataGenerator.Web.LoggingInfrastructure
{
    public class ElmahRedisClient
    {
        private IDatabase _database;
        private IConnectionMultiplexer _connectionMultiplexer;
        private readonly string _connectionString;

        public bool IsConnected => _connectionMultiplexer != null && _connectionMultiplexer.IsConnected;

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
            catch (RedisConnectionException exception)
            {
                _connectionMultiplexer = null;
                _database = null;
                LoggerExtensions.LogError($"Error in ElmahRedisClient: Failed to connect to {_connectionString}! | Exception message: {exception.Message}. | StackTrace: {exception.StackTrace}.");
            }
        }

        private async Task TryToConnectAsync()
        {         
            try
            {
                _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync(_connectionString);
                _database = _connectionMultiplexer.GetDatabase();
            }
            catch (RedisConnectionException exception)
            {
                _connectionMultiplexer = null;
                _database = null;
                LoggerExtensions.LogError($"Error in ElmahRedisClient: Failed to connect to {_connectionString}! | | Exception message: {exception.Message}. | StackTrace: {exception.StackTrace}.");
            }
        }

        public async void SetDataAsync(string key, ErrorData errorData)
        {
            if (!IsConnected)
            {
                await TryToConnectAsync();
            }

            if (!IsConnected) return;

            var value = JsonConvert.SerializeObject(errorData);
            await _database.StringSetAsync(key, value);
        }

        public ErrorData GetData(string key)
        {
            if (!IsConnected)
            {
                TryToConnect();
            }

            if (!IsConnected) return null;

            var value = _database.StringGet(key);
            var result = JsonConvert.DeserializeObject<ErrorData>(value);
            return result;
        }

        public IEnumerable<ErrorData> GetValues(string pattern)
        {
            var values = new List<ErrorData>();
            if (!IsConnected)
            {
                TryToConnect();
            }

            if (!IsConnected) return values;

            var server = _connectionMultiplexer.GetServer(_connectionString);
            var keys = server.Keys(pattern: pattern);

            values.AddRange(keys.Select(key => GetData(key)));
            return values;
        }
    }
}
