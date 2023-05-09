using BL.Models;
using DAL.Entities;

namespace BL.Services
{
    public class TransactionService
    {


        public TransactionService()
        {
            
        }

        public void AddTransactionForUser(Transaction transaction)
        {

        }

        public void DeleteTransaction(int transactionId)
        {

        }

        public void UpdateTransaction(Transaction transaction)
        {

        }

        public decimal GetBalanceForUser()
        {
            return 0;
        }

        public IEnumerable<Transaction> GetTransactionsByFilterForUser(TransactionFilterModel filter)
        {
            return new List<Transaction>();
        }

        public IEnumerable<Transaction> GetAllForUser()
        {
            return new List<Transaction>();
        }
    }
}
