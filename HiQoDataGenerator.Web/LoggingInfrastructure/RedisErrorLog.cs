using System;
using System.Collections.Generic;
using System.Linq;
using ElmahCore;
using Microsoft.Extensions.Options;

namespace HiQoDataGenerator.Web.LoggingInfrastructure
{
    public class RedisErrorLog : ErrorLog
    {
        private readonly ElmahRedisClient _redisClient;

        public RedisErrorLog(IOptions<ElmahOptions> options)
        {
            _redisClient = new ElmahRedisClient(options.Value.ConnectionString);
        }

        public override string Name => "Redis Storage Error Log";

        public override string Log(Error error)
        {
            if (error == null)
                throw new ArgumentNullException(nameof(error));

            var errorXml = ErrorXml.EncodeString(error);
            var id = Guid.NewGuid();
            var redisKey = GetRedisKey(id.ToString());
            var errorLog = new ErrorData
            {
                Id = id,
                Timestamp = error.Time,
                Info = errorXml
            };

            _redisClient.SetDataAsync(redisKey, errorLog);

            return id.ToString();
        }

        public override ErrorLogEntry GetError(string id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id));

            if (id.Length == 0)
                throw new ArgumentException(null, nameof(id));

            Guid errorGuid;

            try
            {
                errorGuid = new Guid(id);
            }
            catch (FormatException e)
            {
                throw new ArgumentException(e.Message, nameof(id), e);
            }

            var redisKey = GetRedisKey(errorGuid.ToString());

            var loggedError = _redisClient.GetData(redisKey);

            var errorInfo = loggedError?.Info;

            if (errorInfo == null)
                return null;

            var error = ErrorXml.DecodeString(errorInfo);
            return new ErrorLogEntry(this, id, error);
        }

        public override int GetErrors(int pageIndex, int pageSize, ICollection<ErrorLogEntry> errorEntryCollection)
        {
            if (pageIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(pageIndex), pageIndex, null);

            if (pageSize < 0)
                throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, null);

            if (errorEntryCollection == null)
                errorEntryCollection = new List<ErrorLogEntry>();

            var allLoggedErrors = _redisClient.GetValues(GetRedisKey("*"));

            var loggedErrors = allLoggedErrors.ToList();
            foreach (var eachLog in loggedErrors.Skip(pageSize * pageIndex).Take(pageSize))
            {
                var error = ErrorXml.DecodeString(eachLog.Info);
                errorEntryCollection.Add(new ErrorLogEntry(this, eachLog.Id.ToString(), error));
            }

            return loggedErrors.Count();
        }

        private static string GetRedisKey(string id)
        {
            return "elmah-error:" + id;
        }
    }
}
