using SSO.Domain.Models.Users;
using SSO.Infra.AppConfiguration;
using SSO.Infra.ServiceLocator;

namespace SSO.Infra.Data.Repositories.Users
{
    public class UserRepository : BaseCrudRepository<User>
    {
        public UserRepository(IServiceLocator serviceLocator) : base(AppSettings.UserCollectionName, serviceLocator)
        {
        }
    }
}
