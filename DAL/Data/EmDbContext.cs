using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class EmDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        private const string DbPath = @"C:\Users\Richard\OneDrive\Počítač\PV178\ExpenseManager\db\expense-manager.db";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
        }
    }
}
