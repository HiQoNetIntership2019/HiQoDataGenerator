using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class ConstraintsRepository: BaseRepository<Constraint>, IConstraintsRepository
    {
        public ConstraintsRepository(DataContext context) : base(context) { }

        public async Task<Constraint> GetByNameAsync(string name) => await _models.FirstAsync(constraint => constraint.Name == name);
    }
}
