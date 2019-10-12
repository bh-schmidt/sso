using MongoDB.Driver;
using SSO.Domain;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using System;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
            mongoDatabase = mongoClient.GetDatabase(collectionName);
            collection = mongoDatabase.GetCollection<TModel>(collectionName);
        }

        protected async Task<bool> Exists(Expression<Func<TModel, bool>> filter)
        {
            var occurrences = await collection.CountDocumentsAsync(filter, new CountOptions() { Limit = 1 });

            return !occurrences.IsZero();
        }
    }
}
