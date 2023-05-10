using BL.Services;
using BL.Services.Interfaces;
using BL.SignedInUserIdentity;
using SimpleInjector;

namespace BL
{
    public class BLIoCSetup
    {
        public static void Register(Container container)
        {
            container.RegisterSingleton<IUserService, UserService>();
            container.RegisterSingleton<ITransactionService, TransactionService>();
            container.RegisterSingleton<ISignedInUserInfo, SignedInUserInfo>();
        }
    }
}
