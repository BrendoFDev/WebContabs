namespace ApiMyContabs.Repository.Entity
{
    
    public class UserBankAccount
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Limit { get; set; }
        public virtual User? User { get; set; }
    }
}
