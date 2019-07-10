using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IServiceSavingGeneratedObjects
    {
        Task MoveToStorage();
    }
}
