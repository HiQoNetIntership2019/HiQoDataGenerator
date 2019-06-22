using HiQoDataGenerator.DAL.Models.DataSetModels;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories.Datasets
{
    public interface ICountriesDatasetRepository : IBaseRepository<CountryDataset>
    {
        bool Contains(string countryName);
    }
}
