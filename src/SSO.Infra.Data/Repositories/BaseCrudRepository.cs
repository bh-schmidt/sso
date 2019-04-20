using System.Collections.Generic;
using System.Threading.Tasks;
using SSO.Domain.Interfaces.Repositories;
using SSO.Domain.Models;
using MongoDB.Driver;

namespace SSO.Infra.Data.Repositories
{
    public abstract class BaseCrudRepository<TModel> : 
        BaseRepository<TModel>, 
        IBaseCrudRepository<TModel> 
        where TModel : BaseModel
    {
        protected BaseCrudRepository(string collectionName) : base(collectionName) { }

        public virtual async Task Delete(string id)
        {
            await collection.DeleteOneAsync(x => x.Id == id);
        }

        public virtual async Task<IEnumerable<TModel>> GetAll()
        {
            var result = await collection.FindAsync(x => true);
            return await result.ToListAsync();
        }

        public virtual async Task<TModel> GetBy(string id)
        {
            var result = await collection.FindAsync(x => true);
            return await result.FirstOrDefaultAsync();
        }

        public virtual async Task Insert(TModel model)
        {
            await collection.InsertOneAsync(model);
        }

        public virtual async Task Replace(TModel model)
        {
            await collection.ReplaceOneAsync(x => x.Id == model.Id, model);
        }
    }
}
