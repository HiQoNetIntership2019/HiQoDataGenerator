using HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus;
using HiQoDataGenerator.EventBus.Events;
using Quartz;
using Serilog;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Scheduler.Jobs
{
    public class PublishEventJob : IJob
    {
        private RabbitMqEventBus _bus;
        private TimerEvent _event;

        public PublishEventJob(RabbitMqEventBus bus, TimerEvent @event)
        {
            _bus = bus;
            _event = @event;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var result = _bus.Publish(_event);

            if (result)
                Log.Information("Service published an event in bus");
            else
                Log.Information("Can't publish an event in bus!");

            return Task.CompletedTask;
        }
    }
}
