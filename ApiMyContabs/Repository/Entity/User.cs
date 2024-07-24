using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiMyContabs.Repository.Entity
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? Password { get; set; }
    }
}
