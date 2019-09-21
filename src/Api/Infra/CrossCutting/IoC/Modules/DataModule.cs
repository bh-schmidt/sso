using Api.Infra.Data.MongoDatabase.Repositories.Users;
using Autofac;
using MongoDB.Driver;
using SSO.Infra.AppConfiguration;

namespace Api.Infra.CrossCutting.IoC.Modules
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
