using Autofac;

namespace UI
{
    internal static class Program
    {
        [STAThread]
        public static void Main()
        {
            ApplicationConfiguration.Initialize();
            var builder = new ContainerBuilder();

            builder.RegisterModule(new UI.DIModule());
            builder.RegisterModule(new BL.DIModule());
            builder.RegisterModule(new DataImport.DIModule());
            builder.RegisterModule(new DataExport.DIModule());
            var serviceProvider = builder.Build();
            var mainBoard = new MainBoard.MainBoard(serviceProvider);
            Application.Run(mainBoard);
        }
    }
}