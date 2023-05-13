using DAL.Data;

var db = new EmDbContext();

Console.WriteLine(db.Transactions.First().TransactionType);
