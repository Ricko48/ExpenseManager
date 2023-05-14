using BL.Models;

namespace DataExport
{
    public interface ITransactionsDataExporter
    {
        Task ExportByFilterAsync(string path, TransactionFilterModel filter);
    }
}
