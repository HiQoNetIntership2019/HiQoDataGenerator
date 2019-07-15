using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;
using HiQoDataGenerator.Scheduler.Extensions;
using Quartz.Impl;
using HiQoDataGenerator.Scheduler.Jobs;
using HiQoDataGenerator.EventBus.EventBuses.RabbitMqEventBus;
using HiQoDataGenerator.EventBus.Events;
using Quartz.Spi;
using System.Collections.Generic;

namespace HiQoDataGenerator.Scheduler.Services
{
    public class SchedulerHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IJobFactory _jobFactory;
        private readonly IEnumerable<JobSchedule> _jobSchedules;
        private IScheduler _scheduler;

        public SchedulerHostedService(ISchedulerFactory schedulerFactory, IJobFactory jobFactory, IEnumerable<JobSchedule> jobSchedules)
        {
            _schedulerFactory = schedulerFactory;
            _jobSchedules = jobSchedules;
            _jobFactory = jobFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _scheduler = await _schedulerFactory.GetScheduler();
            _scheduler.JobFactory = _jobFactory;

            foreach (var jobSchedule in _jobSchedules)
            {
                var job = CreateJob(jobSchedule);
                var trigger = CreateTrigger(jobSchedule);

                await _scheduler.ScheduleJob(job, trigger, cancellationToken);
            }

            await _scheduler.Start(cancellationToken);
            Log.Information("Service started");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Log.Information("Service stopped");
            await _scheduler?.Shutdown(cancellationToken);
        }

        private static IJobDetail CreateJob(JobSchedule schedule)
        {
            var jobType = schedule.JobType;
            return JobBuilder
                .Create(jobType)
                .WithIdentity(jobType.FullName)
                .Build();
        }

        private static ITrigger CreateTrigger(JobSchedule schedule)
        {
            return TriggerBuilder
                .Create()
                .WithIdentity($"{schedule.JobType.FullName}.trigger")
                .WithCronSchedule(schedule.CronExpression)
                .Build();
        }
    }
}
