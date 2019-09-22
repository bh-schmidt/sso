using SSO.Domain.Users;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;

namespace SSO.Infra.Data.MongoDatabase.Repositories.Users
{
    public class UserRepository : BaseCrudRepository<User>, IUserRepository
    {
        public UserRepository(IServiceLocator serviceLocator) : base(AppSettings.UserCollectionName, serviceLocator)
        {
        }
    }
}
