using HiQoDataGenerator.DAL.Contracts.Repositories.Datasets;
using HiQoDataGenerator.DAL.Models.DataSetModels;
using System.Linq;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework.Datasets
{
    public class CountriesDatasetRepository : BaseRepository<CountryDataset>, ICountriesDatasetRepository
    {
        public CountriesDatasetRepository(DataContext context) : base(context) { }
        public bool Contains(string countryName) => _models.Any(item => item.Name == countryName);
        
    }
}
