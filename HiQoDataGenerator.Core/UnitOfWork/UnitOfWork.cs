using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.UnitOfWork
{
    public class UnitOfWork: IUnitOfWork
    {
        public DataContext Context { get; }

        public UnitOfWork(DataContext context)
        {
            Context = context;
        }
        public async Task<int> CommitAsync()
        {
            return await Context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
