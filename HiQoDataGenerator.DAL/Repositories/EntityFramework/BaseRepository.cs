﻿using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        protected DataContext _context;
        protected DbSet<T> _models;

        public BaseRepository(DataContext context)
        {
            _context = context;
            _models = context.Set<T>();
        }

        public async void Add(T item)
        {
            _models.Add(item);
            await _context.SaveChangesAsync();
        }

        public async void AddRange(IEnumerable<T> items)
        {
            _models.AddRange(items);
            await _context.SaveChangesAsync();
        }

        public IQueryable<T> GetAll() => _models;

        public async Task<T> GetById(int id) => await _models.FindAsync(id);

        public async Task<bool> RemoveById(int id)
        {
            var value = _models.Find(id);
            if (value == null)
            {
                return false;
            }
            _models.Remove(value);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}