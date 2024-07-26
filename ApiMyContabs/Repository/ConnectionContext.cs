﻿using Microsoft.EntityFrameworkCore;
using ApiMyContabs.Repository.Entity;
using Npgsql;

namespace ApiMyContabs.Repository
{
    public class ConnectionContext : DbContext
    {
        public DbSet<UserModel> User { get; set; }
        public DbSet<Spender> Spender { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<UserBankAccountModel> UserBankAccount { get; set; }
        public DbSet<UserBillModel> UserBill { get; set; }
        public DbSet<UserInvestimentModel> UserInvestiment { get; set; }
        public DbSet<UserMetaModel> UserMeta { get; set; }
        public DbSet<ViewUserInvestiment> viewUserInvestiment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ViewUserInvestiment>(Entity =>
            {
                Entity.HasNoKey();
                Entity.ToView("view_user_investiment");
                Entity.Property(x => x.UserId).HasColumnName("UserId");
                Entity.Property(x => x.UserName).HasColumnName("UserName");
                Entity.Property(x => x.TotalInvestiment).HasColumnName("TotalInvestiment");
                Entity.Property(x => x.TotalBills).HasColumnName("TotalBills");
                Entity.Property(x => x.MetaDescription).HasColumnName("MetaDescription");
                Entity.Property(x => x.MetaValue).HasColumnName("MetaValue");
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost; Database=MyContabs; Port=5433; User Id=postgres; Password=brendo;");
    }
}
