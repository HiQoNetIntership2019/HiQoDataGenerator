using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models;

namespace HiQoDataGenerator.DAL.Repositories.EntityFramework
{
    class UsersRepository : GenericRepository<User>, IUserRepository
    {
        public UsersRepository(DataContext context) : base(context) { }

        public async Task AddUserAsync(User user)
        {
            await _models.AddAsync(user);
        }

        //TODO: realize reposytory:

        //public async Task DeleteUserByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<User> GetUserByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<IEnumerable<User>> GetUsersAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
