namespace ApiMyContabs.Repository.Entity
{
    public class UserInvestiment
    {
        public int Id { get; set; }
        public string? InvestimentValue { get; set; }
        public string? InvestimentDate { get; set; }
        public User? User { get; set; }
    }
}
