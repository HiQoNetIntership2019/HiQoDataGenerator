using System;
using System.Threading;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Web.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HiQoDataGenerator.Web.Services
{
    public class QueuedDataSavingService : BackgroundService
    {
        private readonly ILogger _logger;
        private readonly IServiceScope _scope;

        public IBackgroundDataSavingTasksQueue DataSavingTasksQueue { get; }

        public QueuedDataSavingService(ILoggerFactory factory, IBackgroundDataSavingTasksQueue backgroundDataSavingTasksQueue,
            IServiceProvider serviceProvider)
        {
            _logger = factory.CreateLogger("Background-queue");
            _scope = serviceProvider.CreateScope();
            DataSavingTasksQueue = backgroundDataSavingTasksQueue;
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Queued Hosted Service is starting");

            while (!cancellationToken.IsCancellationRequested)
            {
                var fileMetadataRepository = _scope.ServiceProvider.GetRequiredService<IFileMetadataService>();

                var workItem = await DataSavingTasksQueue.DequeueAsync(cancellationToken);
                try
                {
                    var metadata = await workItem(cancellationToken);
                    await fileMetadataRepository.AddAsync(metadata);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Message: {ex.Message}; StackTrace: {ex.StackTrace}");
                    throw;
                }
            }

            _logger.LogInformation("Queued Hosted Service is stopping.");
        }

        public override void Dispose()
        {
            _scope?.Dispose();
            base.Dispose();
        }
    }
}