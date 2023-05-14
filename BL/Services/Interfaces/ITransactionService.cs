using BL.Models;
using DAL.Entities;

namespace BL.Services.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransactionForSignedInUserAsync(Transaction transaction);
        Task DeleteTransactionAsync(int transactionId);
        Task UpdateTransactionAsync(Transaction transaction);
        Task<decimal> GetBalanceForSignedInUserWithFilter(TransactionFilterModel filter);
        Task<IEnumerable<Transaction>> GetTransactionsByFilterForSignedInUserAsync(TransactionFilterModel filter);
        Task DeleteTransactionsForUserIdAsync(int userId);
        Task<TransactionFilterModel> GetTransactionsFilterModelForSignedInUserAsync();
        Task<Transaction> GetTransactionByIdAsync(int transactionId);

        Task<IEnumerable<Transaction>> GetAllTransactionsForSignedInUserAsync();
    }
}
