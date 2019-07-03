using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using HiQoDataGenerator.DAL.Contracts.Repositories;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FieldTypesRepository : GenericRepository<FieldType>, IFieldTypeRepository
    {
        public FieldTypesRepository(DataContext context) : base(context) { }

        public async Task<bool> IsContainsAll(IEnumerable<FieldType> fieldTypes)
        {
            return await _models.AllAsync(item => fieldTypes.Contains(item));
        }

       
    }
}
