using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;

namespace HiQoDataGenerator.Core.Interfaces
{
    public interface IUserService
    {
        Task AddUserAsync(UserModel userModel);
        Task<UserModel> GetByIdAsync(int id);
        Task<bool> CheckIsAccessTokenExpiredIn(string accessToken);
    }
}
