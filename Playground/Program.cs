using DAL;
using DAL.Data;
using SimpleInjector;

var container = new Container();
DALIoCSetup.Register(container);

var dbContext = container.GetInstance<EmDbContext>();

Console.WriteLine(dbContext.Users.First().FirstName);
