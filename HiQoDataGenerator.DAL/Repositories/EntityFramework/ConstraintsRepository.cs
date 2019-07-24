using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{

    public class ConstraintsRepository: GenericRepository<Constraint>, IConstraintsRepository
    {
        public ConstraintsRepository(DataContext context) : base(context) { }

        public async Task<Constraint> GetByNameAsync(string name) => await _models.FirstAsync(constraint => constraint.Name == name);

        public async Task<IEnumerable<Constraint>> GetByFieldTypeIdAsync(int id) =>
            await _models
                .Include(constraint => constraint.SupportedTypes)
                .Where(constraint => constraint.SupportedTypes.Any(type => type.FieldTypeId == id))
                .ToListAsync();
    }
}
