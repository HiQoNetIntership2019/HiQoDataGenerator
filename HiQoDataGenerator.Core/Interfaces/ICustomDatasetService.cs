﻿using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface ICustomDatasetService
    {
        IEnumerable<CustomDatasetModel> GetAll();
        Task<CustomDatasetModel> GetByIdAsync(int id);
        IEnumerable<CustomDatasetValueModel> GetAllValues();
        IEnumerable<CustomDatasetValueModel> GetValuesByDatasetId(int id);
        IEnumerable<CustomDatasetValueModel> GetValuesByDatasetName(string name);
        Task AddAsync(CustomDatasetModel customDatasetModel);
        Task AddRangeAsync(IEnumerable<CustomDatasetModel> customDatasetModels);
        Task RemoveByIdAsync(int id);
    }
}
