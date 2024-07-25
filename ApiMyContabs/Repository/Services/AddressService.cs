using Newtonsoft.Json;

namespace ApiMyContabs.Repository.Services
{
    
    public class AddressService : IAddressService
    {
        private ConnectionContext connectionContext = new ConnectionContext();
        public string? GetAddressBySpender(int SpenderId)
        {
            var Result = connectionContext.Address.FirstOrDefault(x => x.Spender.Id == SpenderId);
            return JsonConvert.SerializeObject(Result);
        }

        public string? GetAllAddress()
        {
            var Result = connectionContext.Address.ToList();
            return JsonConvert.SerializeObject(Result);
        }
    }

    public interface IAddressService
    {
        string? GetAddressBySpender(int SpenderId);
        string? GetAllAddress();
    }
}
