using BL.Services;
using DAL.Data;
using DAL.Entities;
using DAL.Enums;

var db = new EmDbContext();

var service = new TransactionService(db, null);

//await service.AddTransactionAsync(new Transaction()
//{
//    Id = 999,
//    Amount = 10,
//    TransactionType = TransactionType.Expense,
//    Date = DateTime.Now,
//    Description = "blabiky",
//    UserId = 1
//});


var t = await service.GetTransactionById(999);

Console.WriteLine(t.Description);

t.Description = "update";

await service.UpdateTransactionAsync(t);

t = await service.GetTransactionById(999);

Console.WriteLine(t.Description);
