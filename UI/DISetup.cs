using Autofac;
using BL.Services;
using BL.Services.Interfaces;
using BL.SignedInUserIdentity;
using DAL.Data;
using DataExport;
using DataImport;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UI
{
    public class DISetup
    {
        public static IContainer RegisteredServices(ContainerBuilder builder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("EmDbContext");
            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<EmDbContext>();
                optionsBuilder.UseSqlite(connectionString);
                return new EmDbContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();

            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<TransactionService>().As<ITransactionService>().SingleInstance();
            builder.RegisterType<SignedInUserInfo>().As<ISignedInUserInfo>().SingleInstance();
            builder.RegisterType<TransactionsDataExporter>().As<ITransactionsDataExporter>().SingleInstance();
            builder.RegisterType<TransactionsDataImporter>().As<ITransactionsDataImporter>().SingleInstance();

            return builder.Build();
        }
    }
}
