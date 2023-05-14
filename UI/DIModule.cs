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
            var absoluteConnectionString = "Data Source=" + Path.Combine(Directory.GetCurrentDirectory(), connectionString);
            // comment this before adding migration
            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<EmDbContext>();
                optionsBuilder.UseSqlite(absoluteConnectionString);
                return new EmDbContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();
        }
    }
}
