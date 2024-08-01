using ApiMyContabs.Repository;
using Newtonsoft.Json;
namespace ApiMyContabs.Repository.Services
{
    public class SpenderService : ISpenderInterface
    {
        private readonly ConnectionContext conn = new ConnectionContext();

        public string? GetAllSpender()
        {
            var Result = conn.Spender.ToList();
            return JsonConvert.SerializeObject(Result);
        }
        public string? GetSpenderById(int id)
        {
            var Result = conn.Spender.FirstOrDefault(x => x.Id == id);
            return JsonConvert.SerializeObject(Result);
        }
        public string? GetSpenderByEmail(string Email)
        {
            var result = conn.Spender.FirstOrDefault(x => x.EmailAddress == Email);
            return JsonConvert.SerializeObject(result);
        }
    }

    public interface ISpenderInterface
    {
        string? GetSpenderById(int id);
        string? GetSpenderByEmail(string name);
        string? GetAllSpender();
    }
}
