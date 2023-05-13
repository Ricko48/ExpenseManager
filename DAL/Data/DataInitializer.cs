using DAL.Entities;
using DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public static class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Id = 1, Description = "Test2", Amount = 10, TransactionType = TransactionType.Income, Date = DateTime.Now, UserId = 1 },
                new Transaction { Id = 2, Description = "Test1", Amount = 2, TransactionType = TransactionType.Expense, Date = DateTime.Now, UserId = 1 }
            );
        }
    }
}
