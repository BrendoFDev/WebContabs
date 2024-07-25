using Microsoft.AspNetCore.Mvc;
using ApiMyContabs.Repository.Services;

namespace ApiMyContabs.Controllers
{
    [ApiController]
    [Route("api/v1/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = new UserService();

        [HttpPost]
        [Route("api/v1/User/{Email}&{Password}")]
        public IActionResult VerifyUserByEmailAndPassword(string Email, string Password)
        {
           string? Response = _userService.GetUserByEmailAndPassword(Email, Password);
           return Ok(Response);
        }

        [HttpGet]
        [Route("api/v1/AllUser")]
        public IActionResult GetAllUser()
        {
            string? Response = _userService.GetAllUser();
            return Ok(Response);
        }
    }
}
