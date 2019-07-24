using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Linq;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFieldRepository : IGenericRepository<Field>
    {
        Task<Field> GetByConfigurableObjectIdAsync(int id);
        Task<IQueryable<Field>> GetAllWithTypesAsync();
    }
}
