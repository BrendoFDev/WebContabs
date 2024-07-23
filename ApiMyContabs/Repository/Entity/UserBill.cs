namespace ApiMyContabs.Repository.Entity
{
    public class UserBill
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? TotalValue { get; set; }
        public int InstallmentAmount { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public User? User { get; set; }
    }
}
