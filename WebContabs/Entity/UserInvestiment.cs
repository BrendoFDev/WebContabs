namespace WebContabs.Entity
{
    public class UserInvestiment
    {
        public virtual int Id { get; set; }
        public virtual string? InvestimentValue { get; set; }
        public virtual string? InvestimentDate { get; set; }
        public virtual User? User { get; set; }
    }
}
