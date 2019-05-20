using SSO.Domain.Models.Users;
using System.Threading.Tasks;

namespace SSO.Domain.Interfaces.Services.Users
{
    public interface IInsertUserService
    {
        Task Insert(User user);
    }
}
