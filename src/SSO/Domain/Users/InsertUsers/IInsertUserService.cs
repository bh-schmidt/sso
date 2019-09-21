using System.Threading.Tasks;

namespace SSO.Domain.Users.InsertUsers
{
    public interface IInsertUserService
    {
        Task<User> Insert(User user);
    }
}
