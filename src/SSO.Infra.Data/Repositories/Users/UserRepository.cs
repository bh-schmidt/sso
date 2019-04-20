using SSO.Domain.Models.Users;

namespace SSO.Infra.Data.Repositories.Users
{
    public class UserRepository : BaseCrudRepository<User>
    {
        public UserRepository() : base("")
        {
        }
    }
}
