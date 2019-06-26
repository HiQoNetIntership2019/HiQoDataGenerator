using HiQoDataGenerator.DAL.Repositories.EntityFramework;
using System;
using System.Threading.Tasks;

namespace HiQoDataGenerator.Core.UnitOfWork
{
   public interface IUnitOfWork: IDisposable
    {
        Task<int> CommitAsync();
    }
}
