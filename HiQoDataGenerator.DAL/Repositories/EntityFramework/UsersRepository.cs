using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<bool> IsUserAlreadyExist(string userId)
        {
            return await _models.AnyAsync(u => u.UserId == userId);
        }

        public async Task<User> FindByUserIdAsync(string userId)
        {
            return await _models.FirstAsync(u => u.UserId == userId);
        }
        
    }
}
