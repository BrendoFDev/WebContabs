using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    [Table("t_usermeta")]
    public class UserMetaModel
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? MetaValue { get; set; }
        public UserModel? User { get; set; }
    }
}
