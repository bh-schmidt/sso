
using SSO.Domain.Users;
using System.Threading.Tasks;

namespace SSO.Infra.Data.MongoDatabase.Repositories.Users
{
    public interface IUserRepository : IBaseCrudRepository<User>
    {
        Task<bool> EmailExists(string email);
        Task<bool> UsernameExists(string username);
    }
}
