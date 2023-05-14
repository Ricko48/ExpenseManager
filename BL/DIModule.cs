using Autofac;
using BL.Services;
using BL.Services.Interfaces;
using BL.SignedInUserIdentity;

namespace BL
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>().SingleInstance();
            builder.RegisterType<TransactionService>().As<ITransactionService>().SingleInstance();
            builder.RegisterType<SignedInUserInfo>().As<ISignedInUserInfo>().SingleInstance();
        }
    }
}
