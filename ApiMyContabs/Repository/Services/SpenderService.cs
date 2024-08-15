using ApiMyContabs.Repository;
using ApiMyContabs.Repository.Entity;
using ApiMyContabs.Repository.FormModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Data.Common;
using System.Text;

namespace ApiMyContabs.Repository.Services
{
    public class SpenderService : ISpenderService
    {
        private readonly ConnectionContext conn = new ConnectionContext();

        public object? GetAllSpender()
        {
            try
            {
                var Result = conn.Spender.ToList();

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + "\n InnerException: " + ex.InnerException);
            }
        }

        public object? GetSpenderById(int id)
        {
            try
            {
                var Result = conn.Spender.FirstOrDefault(x => x.Id == id);

                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + "\n InnerException: " + ex.InnerException);
            }
        }

        public object? GetSpenderByEmail(string Email)
        {
            try
            {
                var result = conn.Spender.FirstOrDefault(x => x.Email == Email);

                return result;
            }
            catch(Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + "\n InnerException: " + ex.InnerException);
            }
        }

        public List<Spender>? GetSpender(SpenderForm SpenderForm)
        {
            try
            {
                Spender? SpenderFilter = ConvertSpenderFormToSpender(SpenderForm);
                
                if(SpenderFilter != null)
                {
                    DbCommand Command = conn.CreateCommand();
                    var Dparams = conn.GetDictionaryFromObject(SpenderForm);

                    Command.CommandText = SelectQueryByParameters(Dparams);
                    Command = conn.AddParameters(Command, Dparams);

                    var SpenderJson = conn.ExecuteReader(Command);
                    List<Spender>? spender = JsonConvert.DeserializeObject<List<Spender>>(SpenderJson);

                    return spender;
                }
                else
                    throw new Exception("Invalid Data In Form");
               
            }
            catch(Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + "\n InnerException: " + ex.InnerException);
            }
        }

        public string SelectQueryByParameters(Dictionary<string, object?> Parameters)
        {
            StringBuilder Sb = new StringBuilder("SELECT * FROM t_spender as spen WHERE 1=1 ");

            foreach (var param in Parameters)
            {
                if (param.Value != null)
                {
                    Sb.Append($" AND spen.\"{param.Key}\" = @{param.Key}");
                }
            }

            return Sb.ToString();
        }

        public object PutSpender(SpenderForm SpenderForm)
        {
            try
            {
                Spender? SpenderFromForm = ConvertSpenderFormToSpender(SpenderForm);

                if (SpenderFromForm != null)
                {
                    conn.Spender.Add(SpenderFromForm);
                    conn.SaveChanges();
                    return SpenderFromForm;
                }
                else
                    throw new Exception("Invalid Data in Form");
            }
            catch(Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + "\n InnerException: " + ex.InnerException);
            }
        }

        private Spender? ConvertSpenderFormToSpender(SpenderForm SpenderForm)
        {
            string SpenderFormJson = JsonConvert.SerializeObject(SpenderForm);
            Spender? SpenderFromForm = JsonConvert.DeserializeObject<Spender>(SpenderFormJson);
            return SpenderFromForm;
        }
    }

    public interface ISpenderService
    {
        object? GetSpenderById(int id);
        object? GetSpenderByEmail(string name);
        object? GetAllSpender();
        List<Spender>? GetSpender(SpenderForm SpenderForm);
        object PutSpender(SpenderForm SpenderForm);
    }
}
