using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.ConstraintModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class ConstraintValuesRepository : BaseRepository<ConstraintValue>, IConstraintValuesRepository
    {
        public ConstraintValuesRepository(DataContext context) : base(context) { }

        public async Task<IEnumerable<ConstraintValue>> GetByTypeAsync(int id)
        {
            return await _models.Where(constraintValue => constraintValue.Constraint.Id == id).ToListAsync();
        }
    }
}
