﻿using System.Collections.Generic;
using HiQoDataGenerator.Core.Entities;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDefinedDatasetService
    {
        IEnumerable<DefinedDatasetModel> GetAll();
        Task<DefinedDatasetModel> GetByIdAsync(int id);
        IEnumerable<DefinedDatasetValueModel> GetValues();
        IEnumerable<DefinedDatasetValueModel> GetValuesByDatasetId(int id);
        IEnumerable<DefinedDatasetValueModel> GetValuesByDatasetName(string name);
        IEnumerable<DefinedDatasetModel> GetDatasetsByTypeId(int id);
        IEnumerable<DefinedDatasetModel> GetDatasetsByTypeName(string name);
        Task<DefinedDatasetModel> GetDatasetWithValuesById(int id);

        Task AddValuesAsync(IEnumerable<DefinedDatasetValueModel> definedDatasetValueModels);
        Task AddAsync(DefinedDatasetModel definedDatasetModel);
        Task RemoveDatasetAsync(int datasetId);
        Task RemoveValueByIdAsync(int valueId);
    }
}
