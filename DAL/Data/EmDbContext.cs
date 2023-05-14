using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public class EmDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        public EmDbContext(DbContextOptions<EmDbContext> options) : base(options) { }

        //Uncomment for the add-migration command

        //public EmDbContext() { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=.\\..\\db\\expense-manager.db");
        //}
    }
}
