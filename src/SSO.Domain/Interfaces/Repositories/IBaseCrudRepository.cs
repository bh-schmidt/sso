using SSO.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSO.Domain.Interfaces.Repositories
{
    public interface IBaseCrudRepository<TModel> where TModel : BaseModel
    {
        Task Delete(string id);
        Task<IEnumerable<TModel>> GetAll();
        Task<TModel> GetBy(string id);
        Task Insert(TModel model);
        Task Replace(TModel model);
    }
}
