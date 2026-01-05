using Microsoft.EntityFrameworkCore;
using MicroservicesIntermediateStorage.Models;

namespace MicroservicesIntermediateStorage.Data
{
    public class BankingDbContext : DbContext
    {
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>().HasKey(a => a.AccountId);
            modelBuilder.Entity<Transaction>().HasKey(t => t.TransactionId);
            modelBuilder.Entity<Notification>().HasKey(n => n.NotificationId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
