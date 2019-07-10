using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Scheduler.Services
{
    internal class SchedulerHostedService : IHostedService, IDisposable
    {
        //private readonly ILogger _logger;
        private Timer _timer;

        public SchedulerHostedService()
        {
           // _logger = logger;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            //_logger.LogInformation("Timed Background Service is starting.");
            Console.WriteLine("Timed Background Service is starting.");

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            //_logger.LogInformation("Timed Background Service is working.");
            Console.WriteLine("Timed Background Service is working.");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //_logger.LogInformation("Timed Background Service is stopping.");
            Console.WriteLine("Timed Background Service is stopping.");
            _timer?.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
