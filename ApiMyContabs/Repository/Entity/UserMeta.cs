using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    [Table("t_usermeta")]
    public class UserMeta
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? MetaValue { get; set; }
        public User? User { get; set; }
    }
}
