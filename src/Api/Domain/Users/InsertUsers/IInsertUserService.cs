using System.Threading.Tasks;

namespace Api.Domain.Users.InsertUsers
{
    public interface IInsertUserService
    {
        Task<User> Insert(User user);
    }
}
