using SSO.Domain.Users;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using System;
using System.Threading.Tasks;

namespace SSO.Infra.Data.MongoDatabase.Repositories.Users
{
    public class UserRepository : BaseCrudRepository<User>, IUserRepository
    {
        public UserRepository(IServiceLocator serviceLocator) : base(AppSettings.UserCollectionName, serviceLocator)
        {
        }

        public async Task<bool> EmailExists(string email)
        {
            email.ThrowIfNullOrEmpty(nameof(email));

            return await Exists(x => x.Email == email);
        }

        public async Task<bool> UsernameExists(string username)
        {
            username.ThrowIfNullOrEmpty(nameof(username));

            return await Exists(x => x.Username == username);
        }
    }
}
