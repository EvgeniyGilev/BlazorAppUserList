using BlazorApp.Server.Interfaces;
using BlazorApp.Shared.Models;
using Microsoft.AspNetCore.Mvc;
namespace BlazorApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _iUser;
        public UserController(IUser iUser)
        {
            _iUser = iUser;
        }

        [HttpGet]
        public List<User> Get()
        {
            return _iUser.GetUserList();
        }

        [HttpGet]
        [Route("Users")]
        public List<User> GetActive(int active)
        {
            if (active == 0)
            {
                return _iUser.GetUserListDeleted();
            }
            else
            {
                return _iUser.GetUserListActive();
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            User user = _iUser.GetUserData(id);
            return Ok(user);
        }

        [HttpPost]
        public void Post(User user)
        {
            _iUser.AddUser(user);
        }

        [HttpPut]
        public void Put(User user)
        {
            _iUser.UpdateUserDetails(user);
        }

        [HttpPatch("{id}")]
        public void Activated(int id)
        {
            var user = _iUser.GetUserData(id);
            user.IsActive = 1;
            _iUser.UpdateUserDetails(user);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _iUser.DeleteUser(id);
            return Ok();
        }
    }
}