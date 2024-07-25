using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    public class ViewUserInvestiment
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public decimal TotalInvestiment { get; set; }
        public decimal TotalBills { get; set; }
        public string MetaDescription { get; set; }
        public string MetaValue { get; set; }
    }
}
