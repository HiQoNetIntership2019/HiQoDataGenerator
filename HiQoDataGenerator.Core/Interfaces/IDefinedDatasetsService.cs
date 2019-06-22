using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Entities.Datasets;
using System;
using System.Collections.Generic;
using System.Text;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDefinedDatasetsService
    {
        DatasetModel<string> GetSetOfStringByName(string name);
        void AddValueIn<T>(string datasetName, DatasetValueModel<T> value);
    }
}
