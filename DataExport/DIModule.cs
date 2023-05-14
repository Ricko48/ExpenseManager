using Autofac;

namespace DataExport
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TransactionsDataExporter>().As<ITransactionsDataExporter>().SingleInstance();
        }
    }
}
