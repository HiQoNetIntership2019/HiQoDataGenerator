using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.Interfaces;

namespace HiQoDataGenerator.Web.Extensions
{
    public class BackgroundDataSavingTasksQueue : IBackgroundDataSavingTasksQueue
    {
        private readonly ConcurrentQueue<Func<CancellationToken, Task<FileMetadataModel>>> _workItems =
            new ConcurrentQueue<Func<CancellationToken, Task<FileMetadataModel>>>();

        private readonly  SemaphoreSlim _signal = new SemaphoreSlim(0);

        public void QueueBackgroundWorkItem(Func<CancellationToken, Task<FileMetadataModel>> workItem)
        {
            _workItems.Enqueue(workItem);
            _signal.Release();
        }

        public async Task<Func<CancellationToken, Task<FileMetadataModel>>> DequeueAsync(CancellationToken token)
        {
            await _signal.WaitAsync(token);
            _workItems.TryDequeue(out var workItem);
            return workItem;
        }
    }
}