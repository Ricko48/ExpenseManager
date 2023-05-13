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
            var serviceProvider = DISetup.RegisteredServices(builder);
            var mainBoard = new MainBoard.MainBoard(serviceProvider);
            Application.Run(mainBoard);
        }
    }
}