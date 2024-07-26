using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    [Table("t_userinvestiment")]
    public class UserInvestimentModel
    {
        [Key]
        public int Id { get; set; }
        public string? InvestimentValue { get; set; }
        public string? InvestimentDate { get; set; }
        public UserModel? User { get; set; }
    }
}
