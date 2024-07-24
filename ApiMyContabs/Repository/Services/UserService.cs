using ApiMyContabs.Repository.Entity;
using Newtonsoft.Json;
using NHibernate;
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
        NHibernateHelper sessionfactory = new NHibernateHelper();
        #endregion


        public string? GetUserByEmailAndPassword(string Email, string Password)
        {
            /* ClearSearch();
             sb.Append("Select user from User as user where user.Email = :email and user.Password = :password");
             Parameters.Add("email", Email);
             Parameters.Add("password", Password);
             Result = persistence.Load(sb.ToString(), Parameters);
             return JsonConvert.SerializeObject(Result);*/
            ClearSearch();
            NHibernate.ISession session = sessionfactory.OpenSession();
            var user = session.Query<User>().FirstOrDefault(x => x.Email == Email && x.Password == Password);
            return user != null ? JsonConvert.SerializeObject(user) : null;
        }

        public string? GetAllUser()
        {
            /*   ClearSearch();
               sb.Append("Select user from User as user");
               Result = persistence.Load(sb.ToString());
               return JsonConvert.SerializeObject(Result);*/
            NHibernate.ISession session = sessionfactory.OpenSession();
            var users = session.Query<User>().ToList();
            return users.Count > 0 ? string.Join(", ", users.Select(u => u.Name)) : null;
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
