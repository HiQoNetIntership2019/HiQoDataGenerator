using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFieldRepository : IGenericRepository<Field>
    {
        Task<Field> GetByConfigurableObjectId(int id);
    }
}
