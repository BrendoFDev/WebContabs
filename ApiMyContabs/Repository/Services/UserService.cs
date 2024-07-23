using Newtonsoft.Json;

namespace ApiMyContabs.Repository.Services
{
    public class UserService : IUserService
    {
        public string? GetUserByEmailAndPassword(string Email, string Password)
        {
          
            return JsonConvert.SerializeObject(Result);
        }

        public string? GetAllUser()
        {
            return JsonConvert.SerializeObject(Result);
        }
    }
    public interface IUserService
    {
        string? GetUserByEmailAndPassword(string Email, string Password);
        string? GetAllUser();
    }
}
