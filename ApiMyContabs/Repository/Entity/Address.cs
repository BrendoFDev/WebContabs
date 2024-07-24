namespace ApiMyContabs.Repository.Entity
{
    public class Address
    {
        public virtual int Id { get; set; }
        public virtual string? StreetName { get; set; }
        public virtual string? Neigborhood { get; set; }
        public virtual string? City { get; set; }
        public virtual string? HouseNumber { get; set; }
        public virtual Spender? Spender { get; set; }
    }
}
