﻿using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models.CustomObjectModels;
using Microsoft.EntityFrameworkCore;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class FieldRepository : BaseRepository<Field>, IFieldRepository
    {
        public FieldRepository(DataContext context) : base(context) { }

        public async Task<Field> GetByConfigurableObjectId(int id) =>
            await _models.FirstAsync(item => item.ConfigurableObject.Id == id);
    }
}