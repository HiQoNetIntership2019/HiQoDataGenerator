using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFieldRepository : IRepository<Field>
    {
        Task<Field> GetByConfigurableObjectId(int id);
    }
}
