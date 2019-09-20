using SSO.Domain.Models.Users;
using System.Threading.Tasks;

namespace SSO.Domain.Services.Users
{
    public interface IInsertUserService
    {
        Task<User> Insert(User user);
    }
}