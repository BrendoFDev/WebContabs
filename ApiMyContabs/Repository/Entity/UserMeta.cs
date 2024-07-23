namespace ApiMyContabs.Repository.Entity
{
  
    public class UserMeta
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? MetaValue { get; set; }
        public User? User { get; set; }
    }
}
