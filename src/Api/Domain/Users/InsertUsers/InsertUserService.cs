using Api.Infra.CrossCutting.ExtensionMethods;
using Api.Infra.CrossCutting.IoC.ServiceLocator;
using Api.Infra.Data.MongoDatabase.Repositories.Users;
using System.Threading.Tasks;

namespace Api.Domain.Users.InsertUsers
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
