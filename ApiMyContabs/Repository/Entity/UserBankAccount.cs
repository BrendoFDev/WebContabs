﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    [Table("t_UserBankAccount")]
    public class UserBankAccount
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Limit { get; set; }
        public User? User { get; set; }
    }
}