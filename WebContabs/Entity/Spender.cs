﻿namespace WebContabs.Entity
{
    public class Spender
    {
        public virtual int Id { get; set; }
        public virtual string? Name { get; set; }
        public virtual string? Profile { get; set; }
        public virtual string? PhoneNumber { get; set; }
        public virtual string? EmailAddress { get; set; }
    }
}
