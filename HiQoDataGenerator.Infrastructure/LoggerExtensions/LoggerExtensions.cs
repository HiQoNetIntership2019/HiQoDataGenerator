using Serilog;
using System;
using System.IO;

namespace HiQoDataGenerator.Infrastructure.LoggerExtensions
{
    public static class LoggerExtensions
    {
        public static void CreateLogger(string fileName)
        {
            var name = $"{fileName}_{DateTime.Now.ToString("ddMMyyyy")}.log";
            var filePath = Path.Combine(AppContext.BaseDirectory, "Logs", name);

            Log.Logger = new LoggerConfiguration()
               .WriteTo.File(filePath)
               .CreateLogger();
        }

        public static void LogInfo(string info)
        {
            Log.Information(info);
        }

        public static void LogError(string errorMessage)
        {
            Log.Error(errorMessage);
        }
    }
}
