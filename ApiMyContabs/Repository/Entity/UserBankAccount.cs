namespace ApiMyContabs.Repository.Entity
{
    
    public class UserBankAccount
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Limit { get; set; }
        public User? User { get; set; }
    }
}
