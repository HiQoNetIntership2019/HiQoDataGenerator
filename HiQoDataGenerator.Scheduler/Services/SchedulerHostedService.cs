using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Scheduler.Services
{
    internal class SchedulerHostedService : IHostedService, IDisposable
    {
        private Timer _timer;

        public SchedulerHostedService() { }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Log.Information("Service started");

            _timer = new Timer(PublishEvent, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void PublishEvent(object state)
        {
            Log.Information("Service published event in bus");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("Service stopped");

            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
