using Api.Domain.Users;
using Api.Infra.CrossCutting.IoC.ServiceLocator;
using SSO.Infra.AppConfiguration;

namespace Api.Infra.Data.MongoDatabase.Repositories.Users
{
    public class UserRepository : BaseCrudRepository<User>, IUserRepository
    {
        public UserRepository(IServiceLocator serviceLocator) : base(AppSettings.UserCollectionName, serviceLocator)
        {
        }
    }
}
