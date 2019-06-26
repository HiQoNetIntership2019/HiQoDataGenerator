using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.UnitOfWork
{
   public interface IUnitOfWork: IDisposable
    {
        DataContext Context { get; }
        Task<int> CommitAsync();
    }
}
