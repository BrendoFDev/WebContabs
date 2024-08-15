using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.FormModels
{
    public class AddressForm
    {
        public int? Id { get; set; }
        public string? StreetName { get; set; }
        public string? Neigborhood { get; set; }
        public string? City { get; set; }
        public string? HouseNumber { get; set; }
        public Spender Spender { get; set; }
    }
}
