using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> IsUserAlreadyExist(string userId);
        Task<User> FindByUserIdAsync(string userId);
    }
}
