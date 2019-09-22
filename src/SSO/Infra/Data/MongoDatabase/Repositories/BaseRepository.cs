using MongoDB.Driver;
using SSO.Domain;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;

namespace SSO.Infra.Data.MongoDatabase.Repositories
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
