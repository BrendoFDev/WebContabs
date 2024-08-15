using ApiMyContabs.Repository.Entity;
using Newtonsoft.Json;

namespace ApiMyContabs.Repository.Services
{

    public class AddressService : IAddressService
    {
        private readonly ConnectionContext conn = new ConnectionContext();

        public object? GetAddressBySpender(int SpenderId)
        {
            try
            {
                var Result = conn.Address.FirstOrDefault(x => x.Spender.Id == SpenderId);
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }

        public object GetAllAddress()
        {
            try
            {
                var Result = conn.Address.ToList();
                return Result;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }

        public object PutAddress(string AddressJson)
        {
            try
            {
                var NewAddress = JsonConvert.DeserializeObject<Address>(AddressJson);
                conn.Address.Add(NewAddress);
                conn.SaveChanges();
                return NewAddress;
            }
            catch (Exception ex)
            {
                throw new Exception("Exception: " + ex.Message);
            }
        }
    }

    public interface IAddressService
    {
        object? GetAddressBySpender(int SpenderId);
        object? GetAllAddress();
        object PutAddress(string Address);
    }
}
