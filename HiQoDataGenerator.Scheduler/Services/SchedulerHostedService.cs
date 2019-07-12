using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus;
using HiQoDataGenerator.EventBus.Events;

namespace HiQoDataGenerator.Scheduler.Services
{
    public class SchedulerHostedService : IDisposable
    {
        private Timer _timer;
        private RabbitMqEventBus _bus;
        private TimerEvent _event;

        public SchedulerHostedService()
        {
            _bus = new RabbitMqEventBus(GetType().Name);
            _event = new TimerEvent("DoWork");
        }

        public Task StartAsync()
        {
            Log.Information("Service started");
            
            _timer = new Timer(PublishEvent, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(10));

            return Task.CompletedTask;
        }

        private void PublishEvent(object state)
        {
            _bus.Publish(_event);
            Log.Information("Service published event in bus");
        }

        public Task StopAsync()
        {
            Log.Information("Service stopped");

            _timer?.Change(Timeout.Infinite, 0);
            Dispose();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _bus.Dispose();
        }
    }
}
