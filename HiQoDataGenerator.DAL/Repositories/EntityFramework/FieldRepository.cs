using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FieldRepository : GenericRepository<Field>, IFieldRepository
    {
        public FieldRepository(DataContext context) : base(context) { }

        public async Task<Field> GetByConfigurableObjectIdAsync(int id) =>
            await _models.FirstAsync(item => item.ConfigurableObject.Id == id);

        public async Task<IQueryable<Field>> GetAllWithTypesAsync()
        {
            return await Task.Run(()=>_models.Include(i => i.FieldType));
        }
    }
}
