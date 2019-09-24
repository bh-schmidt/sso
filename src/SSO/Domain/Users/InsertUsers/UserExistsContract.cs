using FluentValidation;
using SSO.Infra.CrossCutting.ExtensionMethods;
using SSO.Infra.CrossCutting.IoC.ServiceLocator;
using SSO.Infra.Data.MongoDatabase.Repositories.Users;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SSO.Domain.Users.InsertUsers
{
    public class UserExistsContract : AbstractValidator<User>, IUserExistsContract
    {
        private IServiceLocator serviceLocator;

        public UserExistsContract(IServiceLocator serviceLocator)
        {
            if (serviceLocator.IsNull())
            {
                throw new ArgumentNullException(nameof(serviceLocator));
            }

            this.serviceLocator = serviceLocator;

            RuleFor(x => x.Email)
                .NotEmpty()
                .MustAsync(EmailNotExists)
                .WithMessage("This email already exists.");

            RuleFor(x => x.Username)
                .NotEmpty()
                .MustAsync(UsernameNotExists)
                .WithMessage("This username already exists.");
        }

        public async Task<bool> EmailNotExists(string email, CancellationToken _)
        {
            var userRepository = serviceLocator.Resolve<IUserRepository>();

            return !await userRepository.EmailExists(email);
        }

        public async Task<bool> UsernameNotExists(string username, CancellationToken _)
        {
            var userRepository = serviceLocator.Resolve<IUserRepository>();

            return !await userRepository.UsernameExists(username);
        }
    }
}
