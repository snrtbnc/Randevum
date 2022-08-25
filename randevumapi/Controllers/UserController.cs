using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RandevumAPI.Interface;
using RandevumAPI.Objects.DTO;
using Repository.EntitiyModels;

namespace RandevumAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService UserService)
        {
            _userService = UserService;
        }

        [HttpGet, Route("{id}")]
        public async Task<User> GetUser(string id)
        {
            return await _userService.GetUser(id);
        }

        [AllowAnonymous]
        [HttpGet, Route("Userlist")]
        public async Task<List<User>> GetUserList()
        {
            return await _userService.GetUsersAsync();
        }

        [AllowAnonymous]
        [HttpPost, Route("add")]
        public async Task<string> CreateUser(UserDTO User)
        {
            return await _userService.SaveUser(User);
        }

        [HttpPut, Route("update")]
        public async Task<string> UpdateUser(UserDTO User)
        {
            return await _userService.UpdateUser(User);
        }

        [HttpDelete, Route("{id}")]
        public async Task<bool> DeleteUser(string id)
        {
            return await _userService.DeleteUser(id);
        }

        [AllowAnonymous]
        [HttpPost, Route("test")]
        public int Test()
        {
            string a = "sdsdds";
            return System.Convert.ToInt32(a);
        }
    }
}