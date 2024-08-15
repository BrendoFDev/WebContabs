using Microsoft.AspNetCore.Mvc;
using ApiMyContabs.Repository.Services;
using ApiMyContabs.Repository.Entity;
using Newtonsoft.Json;
using ApiMyContabs.Repository.FormModels;

namespace ApiMyContabs.Controllers
{
    [ApiController]
    [Route("api/v1/User")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService = new UserService();

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost]
        [Route("api/v1/User/{Email}&{Password}")]
        public IActionResult VerifyUserByEmailAndPassword(string Email, string Password)
        {
            try
            {
                var Response = _userService.GetUserByEmailAndPassword(Email, Password);
                string UserJson = JsonConvert.SerializeObject(Response);

                return Ok(UserJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("api/v1/AllUser")]
        public IActionResult GetAllUser()
        {
            try
            {
                var Response = _userService.GetAllUser();
                string UserJson = JsonConvert.SerializeObject(Response);

                return Ok(UserJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("api/v1/User")]
        public IActionResult PutUser([FromForm] UserForm User)
        {
            try
            {
                var Request = _userService.PutUser(User);
                string UserJson = JsonConvert.SerializeObject(Request);

                return Ok(UserJson);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
