using BL.Exceptions;
using BL.Models;
using BL.Services.Interfaces;
using BL.SignedInUserIdentity;
using DAL.Data;
using DAL.Entities;
using DAL.Enums;
using Microsoft.EntityFrameworkCore;

namespace BL.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly EmDbContext _dbContext;
        private readonly ISignedInUserInfo _signInUserInfo;

        public TransactionService(EmDbContext dbContext, ISignedInUserInfo signInUserInfo)
        {
            _dbContext = dbContext;
            _signInUserInfo = signInUserInfo;
        }

        public async Task AddTransactionForSignedInUserAsync(Transaction transaction)
        {
            transaction.UserId = _signInUserInfo.UserId.Value;
            await AddTransactionAsync(transaction);
        }


        public async Task DeleteTransactionAsync(int transactionId)
        {
            var transaction = await _dbContext.Transactions.FindAsync(transactionId);
            _dbContext.Transactions.Remove(transaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            var originalTransaction = await GetTransactionById(transaction.Id);
            originalTransaction.Amount = transaction.Amount;
            originalTransaction.Date = transaction.Date;
            originalTransaction.Description = transaction.Description;
            originalTransaction.TransactionType = transaction.TransactionType;
            _dbContext.Transactions.Update(originalTransaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<decimal> GetBalanceForSignedInUserAsync()
        {
            var transactions = await GetAllTransactionsForSignedInUserAsync();

            // cannot be called directly on DbContext because Sqlite :(
            return await Task.Run(() =>
            {
                return transactions
                    .Where(t => t.UserId == _signInUserInfo.UserId.Value)
                    .Aggregate(
                        (decimal)0,
                        (total, next) =>
                            next.TransactionType == TransactionType.Expense ? total - next.Amount : total + next.Amount);
            });
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByFilterForSignedInUserAsync(TransactionFilterModel filter)
        {
            return await _dbContext.Transactions
                .Where(t =>
                    t.UserId == _signInUserInfo.UserId.Value &&
                    (filter.TransactionType != null && t.TransactionType == filter.TransactionType.Value) &&
                    (filter.AmountFrom != null && t.Amount >= filter.AmountFrom) &&
                    (filter.AmountTo != null && t.Amount <= filter.AmountTo) &&
                    (filter.FromDateTime != null && t.Date >= filter.FromDateTime) &&
                    (filter.ToDateTime != null && t.Date <= filter.ToDateTime))
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsForSignedInUserAsync()
        {
            return await _dbContext.Transactions
                .Where(t => t.UserId == _signInUserInfo.UserId.Value)
                .ToListAsync();
        }

        public async Task<Transaction> GetTransactionById(int transactionId)
        {
            var transaction = await _dbContext.Transactions.FindAsync(transactionId);
            if (transaction == null)
            {
                throw new EntityWithGivenIdDoesNotExistException<Transaction>();
            }

            return transaction;
        }

        public async Task DeleteTransactionsForUserIdAsync(int userId)
        {
            _dbContext.Transactions.RemoveRange(_dbContext.Transactions.Where(u => u.UserId == userId));
            await _dbContext.SaveChangesAsync();
        }

        private async Task AddTransactionAsync(Transaction transaction)
        {
            await _dbContext.Transactions.AddAsync(transaction);
            await _dbContext.SaveChangesAsync();
        }
    }
}
