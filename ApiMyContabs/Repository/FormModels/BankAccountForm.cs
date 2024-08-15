using ApiMyContabs.Repository.Entity;

namespace ApiMyContabs.Repository.FormModels
{
    public class BankAccountForm
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Limit { get; set; }
        public Spender? Spender { get; set; }
    }
}

