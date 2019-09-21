using Api.Domain;
using Api.Infra.CrossCutting.IoC.ServiceLocator;
using MongoDB.Driver;
using SSO.Infra.AppConfiguration;

namespace Api.Infra.Data.MongoDatabase.Repositories
{
    public abstract class BaseRepository<TModel> where TModel : BaseModel
    {
        protected readonly IMongoClient mongoClient;
        protected readonly IMongoDatabase mongoDatabase;
        protected readonly IMongoCollection<TModel> collection;

        protected BaseRepository(string collectionName, IServiceLocator serviceLocator)
        {
            mongoClient = serviceLocator.Resolve<IMongoClient>();
            mongoDatabase = mongoClient.GetDatabase(AppSettings.UserCollectionName);
            collection = mongoDatabase.GetCollection<TModel>(collectionName);
        }
    }
}
