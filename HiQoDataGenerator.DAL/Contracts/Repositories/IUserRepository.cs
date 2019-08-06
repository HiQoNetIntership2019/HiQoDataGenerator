using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.DAL.Models;

namespace HiQoDataGenerator.DAL.Contracts.Repositories
{
    interface IUserRepository
    {
        Task AddUserAsync(User user);

        //TODO: realize UserRepositoty:

        //Task<IEnumerable<User>> GetUsersAsync();
        //Task<User> GetUserByIdAsync(int id);
        //Task DeleteUserByIdAsync(int id);
    }
}
