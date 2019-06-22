using HiQoDataGenerator.DAL.Contracts.Repositories.Datasets;
using HiQoDataGenerator.DAL.Models.DataSetModels;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework.Datasets
{
    public class CountriesDatasetRepository : BaseRepository<CountryDataset>, ICountriesDatasetRepository
    {
        public CountriesDatasetRepository(DataContext context) : base(context) { }
    }
}
