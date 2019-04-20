using MongoDB.Driver;
using SSO.Domain.Models;

namespace SSO.Infra.Data.Repositories
{
    public abstract class BaseRepository<TModel> where TModel : BaseModel
    {
        protected readonly IMongoClient mongoClient;
        protected readonly IMongoDatabase mongoDatabase;
        protected readonly IMongoCollection<TModel> collection;

        protected BaseRepository(string collectionName)
        {
            mongoClient = new MongoClient("");
            mongoDatabase = mongoClient.GetDatabase("");
            collection = mongoDatabase.GetCollection<TModel>(collectionName);
        }
    }
}
