namespace WebContabs.Entity
{
    public class BankAccount
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Limit { get; set; }
        public virtual Spender? Spender { get; set; }
    }
}
