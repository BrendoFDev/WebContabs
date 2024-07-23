namespace WebContabs.Entity
{
    public class UserMeta
    {
        public virtual int Id { get; set; }
        public virtual string? Description { get; set; }
        public virtual string? MetaValue { get; set; }
        public virtual User? User { get; set; }
    }
}
