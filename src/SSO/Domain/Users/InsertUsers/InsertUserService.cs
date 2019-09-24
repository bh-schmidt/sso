using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using SSO.Infra.Data.MongoDatabase.Repositories.Users;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SSO.Domain.Users.InsertUsers
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
            user?.Validate<IInsertUserContract>(serviceLocator);

            if (user.IsNullOrInvalid())
            {
                return user;
            }

            await user.ValidateAsync<IUserExistsContract>(serviceLocator);

            if (!user.Valid)
            {
                return user;
            }

            var salt = GenerateSalt();

            user.Salt = Convert.ToBase64String(salt);
            user.Password = CryptPassword(salt, user.Password);

            var userRepository = serviceLocator.Resolve<IUserRepository>();

            var insertedUser = await userRepository.Insert(user);

            return insertedUser;
        }

        public string CryptPassword(byte[] salt, string password)
        {
            var hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA1, 9573, 512 / 8);

            return Convert.ToBase64String(hash);
        }

        public byte[] GenerateSalt()
        {
            byte[] salt = new byte[256 / 8];
            RandomNumberGenerator.Create().GetBytes(salt);
            return salt;
        }
    }
}
