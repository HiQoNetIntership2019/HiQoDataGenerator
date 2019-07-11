using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Scheduler.Services
{
    public class SchedulerHostedService : IDisposable
    {
        private Timer _timer;

        public SchedulerHostedService() { }

        public Task StartAsync()
        {
            Log.Information("Service started");

            _timer = new Timer(PublishEvent, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void PublishEvent(object busEvent)
        {
            Log.Information("Service published event in bus");
        }

        public Task StopAsync()
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
