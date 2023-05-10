using BL.Models;
using DAL.Entities;

namespace BL.Services.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransactionForSignedInUserAsync(Transaction transaction);
        Task DeleteTransactionAsync(int transactionId, bool saveChanges = true);
        Task UpdateTransactionAsync(Transaction transaction);
        Task<decimal> GetBalanceForSignedInUserAsync();
        Task<IEnumerable<Transaction>> GetTransactionsByFilterForUser(TransactionFilterModel filter);
        Task<IEnumerable<Transaction>> GetAllTransactionsForUser();
        Task DeleteTransactionsForUserIdAsync(int userId);
    }
}
