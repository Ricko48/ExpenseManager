using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class EmDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public EmDbContext(DbContextOptions<EmDbContext> options) : base(options)
        {
        }

        //Uncomment this for the initial migration
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=C:\\Users\\Richard\\OneDrive\\Počítač\\PV178\\ExpenseManager\\db\\expense-manager.db");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            DataInitializer.Seed(modelBuilder);
        }
    }
}
