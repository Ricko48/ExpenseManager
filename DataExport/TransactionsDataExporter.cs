using System.Globalization;
using BL.Models;
using BL.Services.Interfaces;
using DAL.Entities;

namespace DataExport
{
    public class TransactionsDataExporter : ITransactionsDataExporter
    {
        private readonly ITransactionService _transactionService;

        public TransactionsDataExporter(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task ExportByFilterAsync(string path, TransactionFilterModel filter)
        {
            var transactions = await _transactionService.GetTransactionsByFilterForSignedInUserAsync(filter);
            try
            {
                await Task.Run(async () => await ExportAsync(path, transactions));
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }

        private async Task ExportAsync(string path, IEnumerable<Transaction> transactions)
        {
            var filePath = Path.Combine(path, "transactions-export.csv");
            await using var writer = new StreamWriter(filePath);

            await writer.WriteLineAsync("Amount,Description,Date");

            foreach (var transaction in transactions)
            {
                await writer.WriteLineAsync($"{transaction.Amount.ToString("0.00", CultureInfo.InvariantCulture)},{transaction.Description},{transaction.Date.ToString("dd-MM-yyyy")}");
            }

            writer.Close();
        }
    }
}
