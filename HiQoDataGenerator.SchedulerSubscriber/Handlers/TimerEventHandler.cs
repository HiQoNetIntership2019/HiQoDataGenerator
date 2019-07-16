using System;
using HiQoDataGenerator.EventBus.Handlers;
using HiQoDataGenerator.EventBus.Events;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.GeneratedObjects;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.Entities;
using Newtonsoft.Json;
using Serilog;
using System.Collections.Generic;

namespace HiQoDataGenerator.SchedulerSubscriber.Handlers
{
    public class TimerEventHandler : IBusEventHandler<TimerEvent>
    {
        private IGeneratedObjectFileSystemService _filesService;
        private IGeneratedObjectsService _mongoService;
        private IFileMetadataService _fileMetadataService;
        private IFileStatusService _fileStatusService;

        public TimerEventHandler(
            IGeneratedObjectFileSystemService filesService, 
            IGeneratedObjectsService mongoService,
            IFileMetadataService fileMetadataService,
            IFileStatusService fileStatusService)
        {
            _fileMetadataService = fileMetadataService;
            _filesService = filesService;
            _mongoService = mongoService;
            _fileStatusService = fileStatusService;
        }

        public async Task Handle(TimerEvent @event)
        {
            try
            {
                var newFileStatus = await _fileStatusService.GetByName("NewFile");
                var inProcessingStatus = await _fileStatusService.GetByName("InProcessing");
                var processingFailStatus = await _fileStatusService.GetByName("ProcessingFail");
                var metadata = await _fileMetadataService.GetByStatusId(newFileStatus.Id);

                await SetStatuses(metadata,inProcessingStatus.Id);
                foreach (var item in metadata)
                {
                    try
                    {
                        var model = await _filesService.ReadFromFile(item.Path);
                        await _mongoService.Add(model);

                        DeleteFile(item);
                        Log.Information("File was successfully moved to MongoDB");
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Exception: {0} | Message: {1} | StackTrace: {2}", ex.GetType().Name, ex.Message, ex.StackTrace);
                        item.StatusId = processingFailStatus.Id;
                        await _fileMetadataService.UpdateAsync(item);
                    }
                }
            }
            catch (InvalidDataException ex)
            {
                Log.Error("Exception: {0} | Message: {1}", ex.GetType().Name, ex.Message);
            }            
        }

        private async void DeleteFile(FileMetadataModel metadata)
        {
            await _fileMetadataService.RemoveAsync(metadata.Id);
            await _filesService.DeleteFile(metadata.Path);
            Log.Information($"File <{metadata.Path}> was removed");
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
