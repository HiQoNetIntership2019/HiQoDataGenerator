using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HiQoDataGenerator.Core.Interfaces;
using HiQoDataGenerator.Core.Entities;
using HiQoDataGenerator.Web.ViewModels;

namespace HiQoDataGenerator.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : RootController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService, IMapperFactory maperFactory) : base(maperFactory)
        {
            _userService = userService;
        }

        /// <summary>
        /// Gets user by id.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpGet("{id}", Name = "Get")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var userModel = await _userService.GetByIdAsync(id);

            var userViewModel = _mapper.Map<UserViewModel>(userModel);

            return Ok(userViewModel);
        }

        /// <summary>
        /// Adds new user.
        /// </summary>
        /// <returns>Status code 200 and view model.</returns>
        [HttpPost]
        public async Task<IActionResult> PostAsync(UserViewModel userViewModel)
        {
            var userModel = _mapper.Map<UserModel>(userViewModel);

            await _userService.AddUserAsync(userModel);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> CheckIsAccessTokenExpiredIn(string accessToken)
        {
            var result = await _userService.CheckIsAccessTokenExpiredIn(accessToken);
            return Ok(result);
        }
    }
}
