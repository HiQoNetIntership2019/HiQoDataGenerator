using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL;

namespace HiQoDataGenerator.Core.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        private DataContext _context { get; }

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
