using BL.Models;
using DAL.Entities;

namespace BL.Services.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransactionForSignedInUserAsync(Transaction transaction);
        Task DeleteTransactionAsync(int transactionId);
        Task UpdateTransactionAsync(Transaction transaction);
        Task<decimal> GetBalanceForSignedInUserAsync();
        Task<IEnumerable<Transaction>> GetTransactionsByFilterForSignedInUserAsync(TransactionFilterModel filter);
        Task<IEnumerable<Transaction>> GetAllTransactionsForSignedInUserAsync();
        Task DeleteTransactionsForUserIdAsync(int userId);

        Task<Transaction> GetTransactionById(int transactionId);
    }
}
