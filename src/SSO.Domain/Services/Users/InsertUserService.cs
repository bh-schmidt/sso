using SSO.Domain.Interfaces.Users;
using SSO.Domain.Models.Entities.Users;
using SSO.Infra.Data.Interfaces.Users;
using SSO.Infra.Helpers.Extensions;
using SSO.Infra.ServiceLocator;
using System.Threading.Tasks;

namespace SSO.Domain.Services.Users
{
    public class InsertUserService : IInsertUserService
    {
        IServiceLocator serviceLocator;

        public InsertUserService(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public async Task<User> Insert(User user)
        {
            user?.ValidateToInsertUser();

            if (user.IsNull() || user.Invalid)
            {
                return user;
            }

            var userRepository = serviceLocator.Resolve<IUserRepository>();

            var insertedUser = await userRepository.Insert(user);

            return insertedUser;
        }
    }
}
