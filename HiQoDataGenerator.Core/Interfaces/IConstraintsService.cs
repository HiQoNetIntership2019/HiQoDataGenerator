using System.Collections.Generic;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IConstraintsService
    {
        IEnumerable<ConstraintModel> GetAll();
        Task<ConstraintModel> GetByName(string name);
    }
}
