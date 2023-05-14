
using BL.Services;
using BL.SignedInUserIdentity;
using DAL.Data;
using DataExport;
using DataImport;

var db = new EmDbContext();
var service = new TransactionService(db, new SignedInUserInfo(){UserId = 1});
//var exporter = new TransactionsDataExporter(service);

//await exporter.ExportAllAsync("C:\\Users\\Richard\\OneDrive\\Počítač\\out");
 var importer = new TransactionsDataImporter(service);

await importer.ImportAsync("C:\\Users\\Richard\\OneDrive\\Počítač\\out\\transactions-export.csv");