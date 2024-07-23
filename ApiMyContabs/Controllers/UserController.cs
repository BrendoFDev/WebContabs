using Microsoft.AspNetCore.Mvc;
using ApiMyContabs.Repository.Services;

namespace ApiMyContabs.Controllers
{
    [ApiController]
    [Route("api/v1/VerifyUser")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = new UserService();

        [HttpPost]
        [Route("User/{Email}&{Password}")]
        public IActionResult VerifyUserByEmailAndPassword(string Email, string Password)
        {
           string? Response = _userService.GetUserByEmailAndPassword(Email, Password);
            if(Response != null)
                return Ok(Response);
            else
                return Ok("User Not Found");
        }

        [HttpGet]
        [Route("api/v1/GetUsers")]
        public IActionResult GetAllUser()
        {
            string? Response = _userService.GetAllUser();
            if (Response != null)
                return Ok(Response);
            else
                return Ok(Response);
        }

    }
}
