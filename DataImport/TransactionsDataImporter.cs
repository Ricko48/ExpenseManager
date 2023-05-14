using BL.Services.Interfaces;
using DAL.Entities;
using DataImport.Exceptions;

namespace DataImport
{
    public class TransactionsDataImporter : ITransactionsDataImporter
    {
        private readonly ITransactionService _transactionService;

        public TransactionsDataImporter(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        public async Task ImportAllAsync(string filePath)
        {
            try
            {
                await Task.Run(async () => await ImportAsync(filePath));
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }

        private async Task ImportAsync(string filePath)
        {
            using var reader = new StreamReader(filePath);

            // skips header row
            await reader.ReadLineAsync();

            while (!reader.EndOfStream)
            {
                var values = (await reader.ReadLineAsync()).Split(',');

                Transaction transaction;
                try
                {
                    transaction = new Transaction
                    {
                        Amount = decimal.Parse(values[0].Replace('.', ',')),
                        Description = values[1],
                        Date = DateTime.Parse(values[2]),
                    };
                }
                catch (Exception)
                {
                    throw new InvalidFileFormatException(Path.GetFileName(filePath));
                }

                await _transactionService.AddTransactionForSignedInUserAsync(transaction);
            }
        }
    }
}
