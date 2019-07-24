using System;
using HiQoDataGenerator.EventBus.Handlers;
using HiQoDataGenerator.EventBus.Events;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Infrastructure.LoggerExtensions;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace HiQoDataGenerator.SchedulerSubscriber.Handlers
{
    public class TimerEventHandler : IBusEventHandler<TimerEvent>
    {
        private IGeneratedObjectFileSystemService _filesService;
        private IGeneratedObjectsService _mongoService;
        private IFileMetadataService _fileMetadataService;
        private IFileStatusService _fileStatusService;
        private readonly int _filesReadingLimit;

        public TimerEventHandler(
            IGeneratedObjectFileSystemService filesService, 
            IGeneratedObjectsService mongoService,
            IFileMetadataService fileMetadataService,
            IFileStatusService fileStatusService,
            IConfiguration configuration)
        {
            _fileMetadataService = fileMetadataService;
            _filesService = filesService;
            _mongoService = mongoService;
            _fileStatusService = fileStatusService;
            _filesReadingLimit = GetFilesReadingLimit(configuration, 10);
        }

        public async Task Handle(TimerEvent @event)
        {
            try
            {
                var newFileStatus = await _fileStatusService.GetByNameAsync("NewFile");
                var inProcessingStatus = await _fileStatusService.GetByNameAsync("InProcessing");
                var processingFailStatus = await _fileStatusService.GetByNameAsync("ProcessingFail");
                var metadata = await _fileMetadataService.GetByStatusIdAsync(newFileStatus.Id, _filesReadingLimit);

                await SetStatuses(metadata,inProcessingStatus.Id);
                foreach (var item in metadata)
                {
                    try
                    {
                        var model = await _filesService.ReadFromFileAsync(item.Path);
                        await _mongoService.AddAsync(model);

                        await DeleteFile(item);
                        LoggerExtensions.LogInfo($"File <{item.Path}> was successfully moved to MongoDB");
                    }
                    catch (Exception ex)
                    {
                        LoggerExtensions.LogError($"Exception: {ex.GetType().Name} | Message: {ex.Message} | File: {item.Path} | StackTrace: {ex.StackTrace}");
                        item.StatusId = processingFailStatus.Id;
                        await _fileMetadataService.UpdateAsync(item);
                    }
                }
            }
            catch (InvalidDataException ex)
            {
                LoggerExtensions.LogError($"Exception: {ex.GetType().Name} | Message: {ex.Message} | StackTrace: {ex.StackTrace}");
            }
            catch (Exception ex)
            {
                LoggerExtensions.LogError($"Exception: {ex.GetType().Name} | Message: {ex.Message} | StackTrace: {ex.StackTrace}");
            }
        }

        private int GetFilesReadingLimit(IConfiguration configuration, int defaultLimit)
        {
            var result = defaultLimit;
            try
            {
                var limit = configuration.GetSection("FilesReadingLimit")?.Value;
                if (limit != null)
                {
                    result = int.Parse(limit);
                }
            }
            catch (FormatException)
            {
                LoggerExtensions.LogError($"Wrong FilesReadingLimit value. Default value {defaultLimit} was applied!");
            }
            return result;
        }

        private async Task DeleteFile(FileMetadataModel metadata)
        {
            await _fileMetadataService.RemoveAsync(metadata.Id);
            await _filesService.DeleteFileAsync(metadata.Path);
            LoggerExtensions.LogInfo($"File <{metadata.Path}> was removed");
        }

        private async Task SetStatuses(IEnumerable<FileMetadataModel> metadata, int statusId)
        {
            foreach (var item in metadata)
            {
                item.StatusId = statusId;
            }
            await _fileMetadataService.UpdateRangeAsync(metadata);
        }
    }
}
