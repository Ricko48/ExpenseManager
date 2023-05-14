namespace DataImport
{
    public interface ITransactionsDataImporter
    {
        Task ImportAllAsync(string path);
    }
}
