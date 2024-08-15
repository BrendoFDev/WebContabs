using ApiMyContabs.Repository;
using ApiMyContabs.Repository.Entity;
using ApiMyContabs.Repository.FormModels;
using Newtonsoft.Json;
using System.Text;

namespace ApiMyContabs.Repository.Services
{
    public class BankAccountService : IBankAccountService
    {
        private ConnectionContext conn = new ConnectionContext();

        public object PutBankAccount(BankAccountForm BankAccountForm)
        {
            try
            {
                BankAccount? BankAccount = ConvertBankAccountFormToBankAccount(BankAccountForm);
                if (BankAccount != null)
                {
                    conn.BankAccount.Add(BankAccount);
                    return BankAccount;
                }
                else
                    return "Invalid Data In Form";
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + "\n InnerException: " + ex.InnerException);
            }
        }

        public List<BankAccount>? GetBankAccount(BankAccountForm bankAccountForm)
        {
            try
            {
                BankAccount? BankAccount = ConvertBankAccountFormToBankAccount(bankAccountForm);
                if (BankAccount != null)
                {
                    var Command = conn.CreateCommand();
                    var Dparams = conn.GetDictionaryFromObject(BankAccount);
                    Command.CommandText = SelectQueryByParameters(Dparams);
                    Command = conn.AddParameters(Command, Dparams);

                    var BankAccountJson = conn.ExecuteReader(Command);
                    List<BankAccount>? bankAccounts = JsonConvert.DeserializeObject<List<BankAccount>>(BankAccountJson);

                    return bankAccounts;
                }
                else
                    throw new Exception("Invalid Data in Form");
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message + "\n InnerException: " + ex.InnerException);
            }
        }

        public string SelectQueryByParameters(Dictionary<string, object?> Parameters)
        {
            StringBuilder Sb = new StringBuilder("SELECT * FROM t_bankaccount as bak WHERE 1=1 ");

            foreach (var param in Parameters)
            {
                if (param.Value != null)
                {
                    Sb.Append($" AND bak.\"{param.Key}\" = @{param.Key}");
                }
            }

            return Sb.ToString();
        }

        public BankAccount? ConvertBankAccountFormToBankAccount(BankAccountForm BankAccountForm)
        {
            string BankAccountJson = JsonConvert.SerializeObject(BankAccountForm);
            BankAccount? BankAccount = JsonConvert.DeserializeObject<BankAccount>(BankAccountJson);
            return BankAccount;
        }
    }

    public interface IBankAccountService
    {
        object PutBankAccount(BankAccountForm BankAccountForm);
        List<BankAccount>? GetBankAccount(BankAccountForm BankAccountForm);
    }
}
