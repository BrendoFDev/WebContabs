using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    [Table("t_Spender")]
    public class Spender
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Profile { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
    }
}
