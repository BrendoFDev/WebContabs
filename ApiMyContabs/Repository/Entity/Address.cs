using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    [Table("t_address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string? StreetName { get; set; }
        public string? Neigborhood { get; set; }
        public string? City { get; set; }
        public string? HouseNumber { get; set; }
        public Spender? Spender { get; set; }
    }
}
