using Autofac;

namespace DataImport
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransactionsDataImporter>().As<ITransactionsDataImporter>().SingleInstance();
        }
    }
}
