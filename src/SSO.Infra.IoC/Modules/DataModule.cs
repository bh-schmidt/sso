using Autofac;
using MongoDB.Driver;
using SSO.Infra.AppConfiguration;
using SSO.Infra.Data.Repositories.Users;

namespace SSO.Infra.IoC.Modules
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserRepository>().As<IUserRepository>();

            var mongoClient = new MongoClient(AppSettings.MongoDbConnectionString);
            builder.RegisterInstance(mongoClient).As<IMongoClient>();
        }
    }
}
