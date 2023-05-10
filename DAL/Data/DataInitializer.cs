using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Data
{
    public static class DataInitializer
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TransactionType>().HasData(
                new TransactionType { Id = 1, Name = "Expense" },
                new TransactionType { Id = 2, Name = "Income" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Bon", LastName = "Ton", UserName = "Bobo", Password = "123" },
                new User { Id = 2, FirstName = "John", LastName = "Lenon", UserName = "Jojo", Password = "123" }
            );

            modelBuilder.Entity<Transaction>().HasData(
                new Transaction { Id = 1, Amount = 100, UserId = 1, Description = "blabla1", TransactionTypeId = 1 },
                new Transaction { Id = 2, Amount = 50, UserId = 2, Description = "blabla2", TransactionTypeId = 2 }
            );
        }
    }
}
