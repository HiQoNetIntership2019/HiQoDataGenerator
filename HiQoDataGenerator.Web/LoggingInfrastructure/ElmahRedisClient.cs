using System.Collections.Generic;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace HiQoDataGenerator.Web.LoggingInfrastructure
{
    public class ElmahRedisClient
    {
        private readonly IDatabase _database;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly string _connectionString;

        public ElmahRedisClient(string connectionString)
        {
            _connectionString = connectionString;
            _connectionMultiplexer = ConnectionMultiplexer.Connect(_connectionString);
            _database = _connectionMultiplexer.GetDatabase();
        }

        public void SetData(string key, ErrorData errorData)
        {
            var value = JsonConvert.SerializeObject(errorData);
            _database.StringSet(key, value);
        }

        public ErrorData GetData(string key)
        {
            var value = _database.StringGet(key);
            return JsonConvert.DeserializeObject<ErrorData>(value);
        }

        public IEnumerable<ErrorData> GetValues(string pattern)
        {
            var server = _connectionMultiplexer.GetServer(_connectionString);
            var keys = server.Keys(pattern: pattern);
            List<ErrorData> values = new List<ErrorData>();
            foreach (var key in keys)
            {
                values.Add(GetData(key));
            }

            return values;
        }
    }
}
