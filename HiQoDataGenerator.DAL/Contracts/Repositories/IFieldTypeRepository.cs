using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IFieldTypeRepository : IGenericRepository<FieldType>
    {
        Task<FieldType> GetByNameAsync(string name);
    }
}
