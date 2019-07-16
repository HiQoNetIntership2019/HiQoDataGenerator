using Serilog;
using System.Threading.Tasks;
using HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus;
using HiQoDataGenerator.SchedulerSubscriber.Handlers;
using HiQoDataGenerator.EventBus.Events;

namespace HiQoDataGenerator.SchedulerSubscriber.Services
{
    public class SubscriberHostedService
    {
        private RabbitMqEventBus _bus;
        private TimerEventHandler _handler;

        public SubscriberHostedService(RabbitMqEventBus bus,TimerEventHandler handler)
        {
            _bus = bus;
            _handler = handler;
        }

        public Task StartAsync()
        {
            Log.Information("Service started");
            var result = _bus.Subscribe<TimerEvent,TimerEventHandler>(_handler);
            if (!result)
                Log.Information("RabbitMQ connection error!");

            return Task.CompletedTask;
        }

        public Task StopAsync()
        {
            Log.Information("Service stopped");
            return Task.CompletedTask;
        }
    }
}
