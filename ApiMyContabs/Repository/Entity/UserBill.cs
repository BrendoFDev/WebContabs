﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiMyContabs.Repository.Entity
{
    [Table("t_userbill")]
    public class UserBillModel
    {
        [Key]
        public int Id { get; set; }
        public string? Description { get; set; }
        public string? TotalValue { get; set; }
        public int InstallmentAmount { get; set; }
        public DateTime? InitialDate { get; set; }
        public DateTime? FinalDate { get; set; }
        public UserModel? User { get; set; }
    }
}
