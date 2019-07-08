using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using System.Linq;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FieldTypesRepository : GenericRepository<FieldType>, IFieldTypeRepository
    {
        public FieldTypesRepository(DataContext context) : base(context) { }

        public async Task<FieldType> GetByNameAsync(string name)
        {
            return await Task.Run(() => _models.Where(model => model.Name.ToLower() == name).FirstOrDefault());
        }
    }
}
