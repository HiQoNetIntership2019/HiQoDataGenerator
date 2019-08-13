using System;
using AutoMapper;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Core.Exceptions;
using HiQoDataGenerator.Core.UnitOfWork;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.DAL.Contracts.Repositories;
using HiQoDataGenerator.DAL.Models;

namespace HiQoDataGenerator.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _uow;
        private readonly IUserRepository _userRepostory;

        public UserService(IMapperFactory mapperFactory, IUnitOfWork uow, IUserRepository userRepostory)
        {
            _mapper = mapperFactory.GetMapper(typeof(CoreServices).Name);
            _uow = uow;
            _userRepostory = userRepostory;
        }

        public async Task AddUserAsync(UserModel userModel)
        { 
            var user = _mapper.Map<User>(userModel);

            bool isAlreadyExist = IsUserAlreadyExist(user).Result;

            if (isAlreadyExist)
            {
                await _userRepostory.UpdateAsync(user);
                return;
            }
            
            await _userRepostory.AddAsync(_mapper.Map<User>(userModel));
            await _uow.CommitAsync();
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            var user = await _userRepostory.GetByIdAsync(id);
            if (user == null)
            {
                throw new InvalidDataException($"Can't get User with id {id} !");
            }
            return _mapper.Map<UserModel>(user);
        }

        private async Task<bool> IsUserAlreadyExist(User user)
        {
            return await _userRepostory.IsUserAlreadyExist(user.UserId);
        }
    }
}
