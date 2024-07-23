namespace ApiMyContabs.Repository.Views
{
    public class ViewUserInvestiment
    {
        public virtual int UserId { get; set; }
        public virtual string? UserName { get; set; }
        public virtual decimal TotalInvestiment { get; set; }
        public virtual decimal TotalBills { get; set; }
        public virtual string? MetaDescription { get; set; }
        public virtual decimal MetaValue { get; set; }
    }
}
