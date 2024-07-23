using Newtonsoft.Json;

namespace ApiMyContabs.Repository.Services
{
    public class UserService : IUserService
    {
        private readonly ConnectionContext conn = new ConnectionContext();
        public string? GetUserByEmailAndPassword(string Email, string Password)
        {
            var Result = conn.User.Where(x=>x.Email == Email && x.Password == Password).FirstOrDefault();
            return JsonConvert.SerializeObject(Result);
        }

        public string? GetAllUser()
        {
            var Result = conn.User.ToList();
            return JsonConvert.SerializeObject(Result);
        }
    }
    public interface IUserService
    {
        string? GetUserByEmailAndPassword(string Email, string Password);
        string? GetAllUser();
    }
}
