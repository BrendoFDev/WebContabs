using Newtonsoft.Json;
using ApiMyContabs.Repository.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;
using ApiMyContabs.Repository.FormModels;


namespace ApiMyContabs.Repository.Services
{
    public class UserService : IUserService
    {
        private readonly ConnectionContext conn = new ConnectionContext();

        public object? GetUserByEmailAndPassword(string? Email, string? Password)
        {
            try
            {
                var Result = conn.User.Where(x => x.Email == Email && x.Password == Password).FirstOrDefault();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }

        public object GetAllUser()
        {
            try
            {
                var Result = conn.User.ToList();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }

        public object PutUser(UserForm UserForm)
        {
            try
            {
                UserModel? UserFromForm = ConvertUserFromToUser(UserForm);

                var verifiedUser = GetUserByEmailAndPassword(UserFromForm.Email, UserFromForm.Password);

                if (verifiedUser == null)
                {
                    conn.User.Add(UserFromForm);
                    conn.SaveChanges();
                    return UserFromForm;
                }
                else
                    throw new Exception("User Already Exists");

            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }

        }

        private UserModel? ConvertUserFromToUser(UserForm UserForm)
        {
            string UserFormJson = JsonConvert.SerializeObject(UserForm);
            UserModel? UserFromForm = JsonConvert.DeserializeObject<UserModel>(UserFormJson);
            return UserFromForm;
        }
    }

    public interface IUserService
    {
        object? GetUserByEmailAndPassword(string Email, string Password);
        object GetAllUser();
        object PutUser(UserForm UserForm);
    }
}
