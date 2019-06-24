using HiQoDataGenerator.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDatasetTypesService
    {
        IEnumerable<DatasetTypeModel> GetAllTypes();
        Task AddTypeAsync(DatasetTypeModel datasetTypeModel);
        Task RemoveById(int id);
        Task<DatasetTypeModel> GetByIdAsync(int id);
    }
}
