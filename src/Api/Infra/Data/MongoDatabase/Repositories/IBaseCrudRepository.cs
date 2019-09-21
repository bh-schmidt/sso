using Api.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Infra.Data.MongoDatabase.Repositories
{
    public interface IBaseCrudRepository<TModel> where TModel : BaseModel
    {
        Task Delete(string id);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetBy(string id);
        Task<TModel> Insert(TModel model);
        Task Replace(TModel model);
    }
}
