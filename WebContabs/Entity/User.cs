﻿namespace WebContabs.Entity
{
    public class User
    {
        public virtual int Id { get; set; } 
        public virtual string? Name { get; set; }
        public virtual string? Email { get; set; }
        public virtual string? Password { get; set; }
    }
}
