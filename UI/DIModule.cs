using Autofac;
using DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UI
{
    public class DIModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connectionString = configuration.GetConnectionString("EmDbContext");

            // comment this before adding migration
            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<EmDbContext>();
                optionsBuilder.UseSqlite(connectionString);
                return new EmDbContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }
    }
}
