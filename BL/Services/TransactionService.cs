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


        public async Task DeleteTransactionAsync(int transactionId, bool saveChanges = true)
        {
            var transaction = await _dbContext.Transactions.FindAsync(transactionId);

            await Task.Run(() =>
            {
                _dbContext.Transactions.Remove(transaction);
            });

            if (saveChanges)
            {
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            await DeleteTransactionAsync(transaction.Id, false);
            await AddTransactionAsync(transaction);
        }

        public async Task<decimal> GetBalanceForSignedInUserAsync()
        {
            if (!_signInUserInfo.IsSignedIn)
            {
                return 0;
            }

            return await Task.Run(() =>
            {
                return _dbContext.Transactions
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
