using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IDatasetRepository : IGenericRepository<Dataset>
    {
        Task<Dataset> GetByNameAsync(string name);
        Task<IEnumerable<Dataset>> GetDatasetsByTypeIdAsync(int id);
        Task<IEnumerable<Dataset>> GetDatasetsByTypeNameAsync(string name);
        Task ToDefinedDatasetAsync(int datasetId);
    }
}
