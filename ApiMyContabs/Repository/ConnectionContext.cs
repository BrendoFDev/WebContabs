using Microsoft.EntityFrameworkCore;
using ApiMyContabs.Repository.Entity;
using Npgsql;

namespace ApiMyContabs.Repository
{
    public class ConnectionContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Spender> Spender { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<BankAccount> BankAccount { get; set; }
        public DbSet<UserBankAccount> UserBankAccount { get; set; }
        public DbSet<UserBill> UserBill { get; set; }
        public DbSet<UserInvestiment> UserInvestiment { get; set; }
        public DbSet<UserMeta> UserMeta { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Server=localhost; Database=MyContabs; Port=5432; User Id=postgres; Password=brendo;");

    }
}
