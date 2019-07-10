using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Diagnostics;
using System.Linq;
using HiQoDataGenerator.Scheduler.Services;
using HiQoDataGenerator.Scheduler.Extensions;
using System.Threading.Tasks;
using Serilog;
using System.IO;

namespace HiQoDataGenerator.Scheduler
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            var isService = !(Debugger.IsAttached || args.Contains("--console"));
                       
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<SchedulerHostedService>();
                });

            ConfigureLogger();

            if (isService)
            {
                await builder.RunAsServiceAsync();
            }
            else
            {
                await builder.RunConsoleAsync();
            }
        }

        private static void ConfigureLogger()
        {
            var fileName = $"Scheduler_{DateTime.Now.ToString("ddMMyyyy")}.log";
            var filePath = Path.Combine(AppContext.BaseDirectory,"Logs",fileName);

            Log.Logger = new LoggerConfiguration()
               .WriteTo.File(filePath)
               .CreateLogger();
        }
    }
}
