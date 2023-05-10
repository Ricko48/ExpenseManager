using DAL.Data;
using SimpleInjector;

namespace DAL
{
    public class DALIoCSetup
    {
        public static void Register(Container container)
        {
            container.RegisterSingleton<EmDbContext>();
        }
    }
}
