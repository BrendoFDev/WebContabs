using Newtonsoft.Json;
using System.Text;

namespace ApiMyContabs.Repository.Services
{
    public class UserService : IUserService
    {
        #region PrivateComponents

        private StringBuilder sb = new StringBuilder();
        private Dictionary<string, object> Parameters = new Dictionary<string, object>();
        private object? Result = null;
        private IPersistence persistence = new Persistence();

        #endregion


        public string? GetUserByEmailAndPassword(string Email, string Password)
        {
            ClearSearch();
            sb.Append("Select user from User as user where user.Email = :email and user.Password = :password");
            Parameters.Add("email", Email);
            Parameters.Add("password", Password);
            Result = persistence.Load(sb.ToString(), Parameters);
            return JsonConvert.SerializeObject(Result);
        }

        public string? GetAllUser()
        {
            ClearSearch();
            sb.Append("Select user from User as user");
            Result = persistence.Load(sb.ToString());
            return JsonConvert.SerializeObject(Result);
        }

        public void ClearSearch()
        {
            sb.Clear();
            Parameters.Clear();
        }
    }
    public interface IUserService
    {
        string? GetUserByEmailAndPassword(string Email, string Password);
        string? GetAllUser();
    }
}
