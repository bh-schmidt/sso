using System.Threading.Tasks;

namespace SSO.Domain.Users.InsertUsers
{
    public interface IInsertUser
    {
        Task<User> Insert(User user);
    }
}
