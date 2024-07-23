namespace WebContabs.Entity
{
    public class UserBill
    {
        public virtual int Id { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? TotalValue { get; set; }
        public virtual int InstallmentAmount { get; set; }
        public virtual DateTime? InitialDate { get; set; }
        public virtual DateTime? FinalDate { get; set; }
        public virtual User? User { get; set; }
    }
}
