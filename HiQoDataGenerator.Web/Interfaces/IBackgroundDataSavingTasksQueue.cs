using System;
using System.Threading;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Web.Interfaces
{
    public interface IBackgroundDataSavingTasksQueue
    {
        void QueueBackgroundWorkItem(Func<CancellationToken, Task<FileMetadataModel>> workItem);
        Task<Func<CancellationToken, Task<FileMetadataModel>>> DequeueAsync(CancellationToken token);
    }
}