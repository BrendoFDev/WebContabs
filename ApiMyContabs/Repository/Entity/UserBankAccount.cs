using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    [Table("t_userbankaccount")]
    public class UserBankAccountModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Limit { get; set; }
        public UserModel? User { get; set; }
    }
}
