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

        /// <summary>
        /// checks, if access token lifetime expired
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns>true if expired</returns>
        public async Task<bool> CheckIsAccessTokenExpiredIn(string accessToken)
        {
            if (accessToken == null)
            {
                throw new ArgumentNullException(nameof(accessToken));
            }

            var userWithToken = await _models.FirstAsync(u => u.AccessToken == accessToken);

            return (DateTime.Compare(userWithToken.ExpiresIn, DateTime.UtcNow)) < 0;
        }
    }
}
