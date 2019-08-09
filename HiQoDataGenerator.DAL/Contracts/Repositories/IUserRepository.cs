using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetUserByIdAsync(int id);
    }
}
