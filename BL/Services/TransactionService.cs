using BL.Exceptions;
using BL.Models;
using BL.Services.Interfaces;
using BL.SignedInUserIdentity;
using DAL.Data;
using DAL.Entities;
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
            var originalTransaction = await GetTransactionByIdAsync(transaction.Id);
            originalTransaction.Amount = transaction.Amount;
            originalTransaction.Date = transaction.Date;
            originalTransaction.Description = transaction.Description;
            _dbContext.Transactions.Update(originalTransaction);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<decimal> GetBalanceForSignedInUserWithFilter(TransactionFilterModel filter)
        {
            var transactions = await _dbContext.Transactions
                .Where(t =>
                    t.UserId == _signInUserInfo.UserId.Value &&
                    t.Amount >= filter.AmountFrom &&
                    t.Amount <= filter.AmountTo &&
                    t.Date >= filter.FromDateTime &&
                    t.Date <= filter.ToDateTime)
                .ToListAsync();

            // does not work in Sqlite with decimal type
            return transactions.Sum(t => t.Amount);
        }

        public async Task<TransactionFilterModel> GetTransactionsFilterModelForSignedInUserAsync()
        {
            var transactions = await GetAllTransactionsForSignedInUserAsync();

            if (!transactions.Any())
            {
                return new TransactionFilterModel();
            }

            var orderedByDate = transactions.OrderBy(x => x.Date);
            var orderedByAmount = transactions.OrderBy(x => x.Amount);

            return new TransactionFilterModel
            {
                AmountTo = orderedByAmount.Last().Amount,
                AmountFrom = orderedByAmount.First().Amount,
                FromDateTime = orderedByDate.First().Date,
                ToDateTime = orderedByDate.Last().Date
            };
        }

        public async Task<IEnumerable<Transaction>> GetTransactionsByFilterForSignedInUserAsync(TransactionFilterModel filter)
        {
            return await _dbContext.Transactions
                .Where(t =>
                    t.UserId == _signInUserInfo.UserId.Value &&
                    t.Amount >= filter.AmountFrom &&
                    t.Amount <= filter.AmountTo &&
                    t.Date >= filter.FromDateTime &&
                    t.Date <= filter.ToDateTime)
                .ToListAsync();
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsForSignedInUserAsync()
        {
            return await _dbContext.Transactions
                .Where(t => t.UserId == _signInUserInfo.UserId.Value)
                .ToListAsync();
        }

        public async Task<Transaction> GetTransactionByIdAsync(int transactionId)
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
