using SSO.Infra.CrossCutting.Cryptography;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using SSO.Infra.Data.MongoDatabase.Repositories.Users;
using System;
using System.Threading.Tasks;

namespace SSO.Domain.Users.InsertUsers
{
    public class InsertUser : IInsertUser
    {
        IServiceLocator serviceLocator;

        public InsertUser(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public async Task<User> Insert(User user)
        {
            if (!await IsValid(user))
            {
                return user;
            }

            var cryptography = serviceLocator.Resolve<IPasswordCryptography>();
            var salt = cryptography.GenerateRandomSalt(64);

            user.Salt = Convert.ToBase64String(salt);
            user.Password = cryptography.EncryptPassword(user.Password, salt);

            var userRepository = serviceLocator.Resolve<IUserRepository>();
            var insertedUser = await userRepository.Insert(user);

            return insertedUser;
        }

        private async Task<bool> IsValid(User user)
        {
            user?.Validate<IInsertUserContract>(serviceLocator);

            if (user.IsNullOrInvalid())
            {
                return false;
            }

            await user.ValidateAsync<IUserExistsContract>(serviceLocator);

            return user.Valid;
        }
    }
}
