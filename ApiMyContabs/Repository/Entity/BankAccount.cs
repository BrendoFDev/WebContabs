namespace ApiMyContabs.Repository.Entity
{

    public class BankAccount
    {
       
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Limit { get; set; }
        public Spender? Spender { get; set; }
    }
}
