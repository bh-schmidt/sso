using SSO.Domain.Models.Entities.Users;
using System.Threading.Tasks;

namespace SSO.Domain.Interfaces.Users
{
    public interface IInsertUserService
    {
        Task<User> Insert(User user);
    }
}
