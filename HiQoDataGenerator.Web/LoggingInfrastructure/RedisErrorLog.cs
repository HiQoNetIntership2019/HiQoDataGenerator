using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ElmahCore;
using Microsoft.Extensions.Options;
using HiQoDataGenerator.Infrastructure.LoggerExtensions;
using HiQoDataGenerator.Web.Exceptions;

namespace HiQoDataGenerator.Web.LoggingInfrastructure
{
    public class RedisErrorLog : ErrorLog
    {
        private readonly ElmahRedisClient _redisClient;
        public RedisErrorLog(IOptions<ElmahOptions> options)
        {
            LoggerExtensions.CreateLogger("Elmah");
            _redisClient = new ElmahRedisClient(options.Value.ConnectionString);
        }

        public override string Name => "Redis Storage Error Log";

        public override string Log(Error error)
        {
            if (error == null)
            {
                var paramName = nameof(error);
                LoggerExtensions.LogError($"Error in RedisErrorLog: {paramName} null reference.");
                throw new ArgumentNullException(paramName);
            }

            if (error.Exception != null)
            {
                if (error.Exception is HttpException)
                {
                    error.StatusCode = ((HttpException) error.Exception).StatusCode;
                    error.Type = "HTTP";
                }
                else
                {
                    error.StatusCode = (int) HttpStatusCode.InternalServerError;
                }
            }

            var errorXml = ErrorXml.EncodeString(error);
            var id = Guid.NewGuid();
            var redisKey = GetRedisKey(id);
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
            var paramName = nameof(id);
            if (id == null)
            {
                LoggerExtensions.LogError($"Error in RedisErrorLog: {paramName} null reference.");
                throw new ArgumentNullException(paramName);
            }

            if (id.Length == 0)
            {
                var message = $"{paramName} can't be empty.";
                LoggerExtensions.LogError($"Error in RedisErrorLog: {message}.");
                throw new ArgumentException(message, paramName);
            }

            Guid errorGuid;

            try
            {
                errorGuid = new Guid(id);
            }
            catch (FormatException exception)
            {
                LoggerExtensions.LogError($"Error in RedisErrorLog: {paramName} invalid format.");
                throw new ArgumentException(exception.Message, paramName, exception);
            }

            var redisKey = GetRedisKey(errorGuid);

            var loggedError = _redisClient.GetData(redisKey);

            var errorInfo = loggedError?.Info;

            if (errorInfo == null)
            {
                return null;
            }

            var error = ErrorXml.DecodeString(errorInfo);
            return new ErrorLogEntry(this, id, error);
        }

        public override int GetErrors(int pageIndex, int pageSize, ICollection<ErrorLogEntry> errorEntryCollection)
        {
            if (pageIndex < 0)
            {
                var paramName = nameof(pageIndex);
                var message = $"Argument {paramName} can't have negative value!";
                LoggerExtensions.LogError($"Error in RedisErrorLog: {message}");
                throw new ArgumentOutOfRangeException(paramName, pageIndex, message);
            }

            if (pageSize < 0)
            {
                var paramName = nameof(pageSize);
                var message = $"Argument {paramName} has negative value.";
                LoggerExtensions.LogError($"Error in RedisErrorLog: {message}");
                throw new ArgumentOutOfRangeException(paramName, pageSize, message);
            }

            if (errorEntryCollection == null)
            {
                errorEntryCollection = new List<ErrorLogEntry>();
            }

            var allLoggedErrors = _redisClient.GetValues(GetRedisKey("*"));

            var loggedErrors = allLoggedErrors.ToArray();
            foreach (var eachLog in loggedErrors.Skip(pageSize * pageIndex).Take(pageSize))
            {
                var error = ErrorXml.DecodeString(eachLog.Info);
                errorEntryCollection.Add(new ErrorLogEntry(this, eachLog.Id.ToString(), error));
            }

            return loggedErrors.Count();
        }

        private static string GetRedisKey(Guid id)
        {
            return $"elmah-error:{id}";
        }

        private static string GetRedisKey(string key)
        {
            return $"elmah-error:{key}";
        }
    }
}
