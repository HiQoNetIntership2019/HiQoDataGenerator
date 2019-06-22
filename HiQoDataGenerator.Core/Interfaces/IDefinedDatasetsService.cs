using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Entities.Datasets;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IDefinedDatasetsService
    {
        DatasetModel<string> GetSetOfStringByName(string name);
        Task AddValueIn<T>(string datasetName, DatasetValueModel<T> value);
        Task<bool> RemoveValueByIdFrom<T>(string datasetName, int id);
    }
}
